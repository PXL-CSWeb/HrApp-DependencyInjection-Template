using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HrApp.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "login-type")]
    public class HyperlinkTagHelper : TagHelper
    {
        public LoginType LoginType { get; set; } = LoginType.Username;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Clear();

            switch (LoginType)
            {
                case LoginType.Username:
                    output.Content.AppendHtml("<i class=\"fa-solid fa-user\"></i>"
                                            + "<h4>Username</h4>");
                    break;
                case LoginType.Email:
                    output.Content.AppendHtml("<i class=\"fa-solid fa-at\"></i>"
                                            + "<h4>Email</h4>");
                    break;
                case LoginType.Facebook:
                    output.Content.AppendHtml("<i class=\"fa-brands fa-facebook\"></i>"
                                            + "<h4>Facebook</h4>");
                    break;
                case LoginType.Google:
                    output.Content.AppendHtml("<i class=\"fa-brands fa-google\"></i>"
                                            + "<h4>Google</h4>");
                    break;
                case LoginType.External:
                    output.Content.AppendHtml("<i class=\"fa-solid fa-fingerprint\"></i>"
                                            + "<h4>Open Id</h4>");
                    break;
                default:
                    output.Content.AppendHtml("<i class=\"fa-solid fa-question\"></i>"
                                            + "<h4>Unknown</h4>");
                    break;
            }

        }
    }

    public enum LoginType
    {
        Username,
        Email,
        Facebook,
        Google,
        External
    }
}
