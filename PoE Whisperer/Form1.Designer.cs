namespace PoE_Whisperer
{
    partial class WhispererForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhispererForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startstopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_pb = new System.Windows.Forms.TextBox();
            this.label_pb = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_browse = new System.Windows.Forms.Button();
            this.label_client_path = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_client_path = new System.Windows.Forms.TextBox();
            this.button_start_stop = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "PoE Whisperer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startstopToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // startstopToolStripMenuItem
            // 
            this.startstopToolStripMenuItem.Name = "startstopToolStripMenuItem";
            this.startstopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startstopToolStripMenuItem.Text = "Start";
            this.startstopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // textBox_pb
            // 
            this.textBox_pb.Location = new System.Drawing.Point(173, 28);
            this.textBox_pb.Name = "textBox_pb";
            this.textBox_pb.Size = new System.Drawing.Size(475, 20);
            this.textBox_pb.TabIndex = 0;
            this.textBox_pb.UseSystemPasswordChar = true;
            // 
            // label_pb
            // 
            this.label_pb.AutoSize = true;
            this.label_pb.Location = new System.Drawing.Point(26, 31);
            this.label_pb.Name = "label_pb";
            this.label_pb.Size = new System.Drawing.Size(128, 13);
            this.label_pb.TabIndex = 1;
            this.label_pb.Text = "Pushbullet Access Token";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(173, 104);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 2;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.Button_browse_Click);
            // 
            // label_client_path
            // 
            this.label_client_path.AutoSize = true;
            this.label_client_path.Location = new System.Drawing.Point(26, 80);
            this.label_client_path.Name = "label_client_path";
            this.label_client_path.Size = new System.Drawing.Size(71, 13);
            this.label_client_path.TabIndex = 3;
            this.label_client_path.Text = "Client.txt path";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(173, 200);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // textBox_client_path
            // 
            this.textBox_client_path.Location = new System.Drawing.Point(173, 72);
            this.textBox_client_path.Name = "textBox_client_path";
            this.textBox_client_path.ReadOnly = true;
            this.textBox_client_path.Size = new System.Drawing.Size(475, 20);
            this.textBox_client_path.TabIndex = 5;
            // 
            // button_start_stop
            // 
            this.button_start_stop.Location = new System.Drawing.Point(372, 199);
            this.button_start_stop.Name = "button_start_stop";
            this.button_start_stop.Size = new System.Drawing.Size(75, 23);
            this.button_start_stop.TabIndex = 7;
            this.button_start_stop.Text = "Start";
            this.button_start_stop.UseVisualStyleBackColor = true;
            this.button_start_stop.Click += new System.EventHandler(this.Button_start_stop_Click);
            // 
            // WhispererForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 287);
            this.Controls.Add(this.button_start_stop);
            this.Controls.Add(this.textBox_client_path);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_client_path);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.label_pb);
            this.Controls.Add(this.textBox_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WhispererForm";
            this.Text = "PoE Whisperer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBox_pb;
        private System.Windows.Forms.Label label_pb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Label label_client_path;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_client_path;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button button_start_stop;
        private System.Windows.Forms.ToolStripMenuItem startstopToolStripMenuItem;
    }
}

