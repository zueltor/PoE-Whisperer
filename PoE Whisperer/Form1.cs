using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Globalization;

namespace PoE_Whisperer
{
    public partial class WhispererForm : Form
    {
        static string token = Properties.Settings.Default.token;
        static double time = 0;
        static int errors = 0;
        static string LastWhisperer = "";
        static string clientpath = "";
        static Stream stream;
        static StreamReader file;
        static System.Timers.Timer timer = new System.Timers.Timer(5000);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string classname, string windowname);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public WhispererForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon1;
            notifyIcon1.Icon = Properties.Resources.icon1;
            textBox_pb.Text = Properties.Settings.Default.token;
            textBox_client_path.Text = Properties.Settings.Default.clientpath;

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized &&
                Screen.GetWorkingArea(this).Contains(Cursor.Position))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void Button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "client.txt|*.txt";
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_client_path.Text = opf.FileName;
            }
            opf.Dispose();
        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.token = textBox_pb.Text;
            Properties.Settings.Default.clientpath = textBox_client_path.Text;
            Properties.Settings.Default.Save();
        }

        private void Button_start_stop_Click(object sender, EventArgs e)
        {
            if (textBox_pb.Text == "none" || textBox_client_path.Text == "none")
            {
                MessageBox.Show("Please enter access token and client.txt path");
                return;
            }
            if (button_start_stop.Text == "Start")
            {
                errors = 0;
                notifyIcon1.BalloonTipText = "Started";
                notifyIcon1.ShowBalloonTip(1000);
                startstopToolStripMenuItem.Text = "Stop";
                clientpath = Properties.Settings.Default.clientpath;
                token = Properties.Settings.Default.token;
                stream = File.Open(clientpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                file = new StreamReader(stream);
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Icon = Properties.Resources.icon2;
                button_start_stop.Text = "Stop";
                startstopToolStripMenuItem.Text = "Stop";

                while (file.ReadLine() != null) ;
                Get();
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

            }
            else
            {
                notifyIcon1.Icon = Properties.Resources.icon1;
                button_start_stop.Text = "Start";
                startstopToolStripMenuItem.Text = "Start";
                timer.Stop();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button_start_stop_Click(sender, e);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private static void Whisp(string name, string text)
        {
            Clipboard.SetText("@" + name + " " + text);
            IntPtr whandle = FindWindow("POEWindowClass", "Path of Exile");
            if (whandle == IntPtr.Zero)
            {
                MessageBox.Show("Path of Exile is not opened");
                return;
            }
            SetForegroundWindow(whandle);
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(Clipboard.GetText());
            SendKeys.SendWait("{ENTER}");
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (errors == 1)
                return;
            Page page = Get();
            if (page != null)
            {
                foreach (var pm in page.pushes)
                {
                    if (pm.direction == "self" && pm.guid != null)
                    {
                        Regex pattern = new Regex("^(?:to|To) (\\S*) (.*)");
                        Match match = pattern.Match(pm.body);
                        if (match.Success)
                        {
                            Whisp(match.Groups[1].Value, match.Groups[2].Value);
                        }
                        else if (pm.body.StartsWith("r ") || pm.body.StartsWith("R "))
                        {
                            if (LastWhisperer != "")
                            {
                                Whisp(LastWhisperer, pm.body.Substring(2));
                            }
                        }
                    }
                }
            }
            string str = file.ReadToEnd();
            string[] lines = str.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                Regex pattern = new Regex("@(From){1,1} (?:<.*> )?((?:[^:])*): (.*)\\s");
                Match match = pattern.Match(lines[i]);
                if (match.Success)
                {
                    Post(match.Groups[2].Value, match.Groups[3].Value);
                }
            }
        }

        public static Page Get()
        {
            WebRequest request;
            if (time == 0)
            {
                request = WebRequest.Create("https://api.pushbullet.com/v2/pushes");
            }
            else
                request = WebRequest.Create("https://api.pushbullet.com/v2/pushes?modified_after=" + (time + 0.00001).ToString("G", CultureInfo.InvariantCulture));
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);
            request.ContentType = "application/json; charset=UTF-8";
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                errors = 1;
                MessageBox.Show(ex.Message);
            }
            if (response != null)
            {
                string responseJson;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    responseJson = sr.ReadToEnd();

                    Page p = JsonConvert.DeserializeObject<Page>(responseJson);
                    if (p.pushes.Count > 0)
                    {
                        time = p.pushes[0].modified;
                    }
                    return p;
                }
            }
            else return null;
        }

        public static void Post(string title = "testt", string body = "testb")
        {
            var request = System.Net.WebRequest.Create("https://api.pushbullet.com/v2/pushes") as System.Net.HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + token);
            byte[] data = Encoding.UTF8.GetBytes(String.Format("{{ \"type\": \"note\", \"title\": \"{0}\", \"body\": \"{1}\"}}", title, body));
            request.ContentLength = data.Length;
            String responseJson;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                LastWhisperer = title;
            }

            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseJson = reader.ReadToEnd();
                }
            }
        }

        public static class Clipboard
        {
            public static void SetText(string p_Text)
            {
                Thread STAThread = new Thread(
                    delegate ()
                    {
                        System.Windows.Forms.Clipboard.SetText(p_Text);
                    });
                STAThread.SetApartmentState(ApartmentState.STA);
                STAThread.Start();
                STAThread.Join();
            }
            public static string GetText()
            {
                string ReturnValue = string.Empty;
                Thread STAThread = new Thread(
                    delegate ()
                    {
                        ReturnValue = System.Windows.Forms.Clipboard.GetText();
                    });
                STAThread.SetApartmentState(ApartmentState.STA);
                STAThread.Start();
                STAThread.Join();

                return ReturnValue;
            }
        }

    }
}
