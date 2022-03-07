using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.CustomTagHelpers
{
    [HtmlTargetElement("myEmail")]
    public class MailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var mailTo = MailTo;
            output.Attributes.SetAttribute("href", "MailTo:" + mailTo);
        }
    }
}
