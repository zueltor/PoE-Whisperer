using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_Whisperer
{
    public class Page
    {
        public List<object> accounts { get; set; }
        public List<object> blocks { get; set; }
        public List<object> channels { get; set; }
        public List<object> chats { get; set; }
        public List<object> clients { get; set; }
        public List<object> contacts { get; set; }
        public List<object> devices { get; set; }
        public List<object> grants { get; set; }
        public List<Push> pushes { get; set; }
        public List<object> profiles { get; set; }
        public List<object> subscriptions { get; set; }
        public List<object> texts { get; set; }
    }

    public class Push
    {
        public bool active { get; set; }
        public string iden { get; set; }
        public double created { get; set; }
        public double modified { get; set; }
        public string type { get; set; }
        public bool dismissed { get; set; }
        public string direction { get; set; }
        public string sender_iden { get; set; }
        public string sender_email { get; set; }
        public string sender_email_normalized { get; set; }
        public string sender_name { get; set; }
        public string receiver_iden { get; set; }
        public string receiver_email { get; set; }
        public string receiver_email_normalized { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string guid { get; set; }
        public string source_device_iden { get; set; }
        public List<string> awake_app_guids { get; set; }
        public string target_device_iden { get; set; }
    }
}
