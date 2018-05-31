using Owin;

namespace Jacaranda.Owin.Security.Wechat
{
    public static class IAppBuilderExtensions
    {
        public static void UseWechatAuthentication(this IAppBuilder app, WechatAuthenticationOptions options)
        {
            if (options != null)
            {
                app.Use<WechatAuthentication>(options);
            }
        }
    }
}
