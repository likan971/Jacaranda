using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Jacaranda.Owin.Security.Wechat
{
    public class WechatAuthentication : OwinMiddleware
    {
        private WechatAuthenticationOptions _options;

        public WechatAuthentication(OwinMiddleware next, WechatAuthenticationOptions options) : base(next)
        {
            _options = options;
        }

        public async override Task Invoke(IOwinContext context)
        {
            System.Diagnostics.Debug.WriteLine(nameof(WechatAuthentication) + " works");
            await Next.Invoke(context);
        }
    }
}
