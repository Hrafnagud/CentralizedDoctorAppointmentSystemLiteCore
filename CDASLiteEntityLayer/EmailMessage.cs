using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer
{
    public class EmailMessage
    {
        //Entities are created here. Now we need to use BLL to send email.
        public string[] Contacts { get; set; }
        public string[] Cc { get; set; }
        public string[] Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
