using System;
using System.Web;

namespace TableLiveEdit.Core.Models
{
    partial class Request
    {
        public static Request Create(HttpRequestBase request)
        {
            return new Request
            {
                IpAddress = request.UserHostAddress,
                Count = 1,
                HostName = request.UserHostName,
                Browser = request.Browser.Browser ?? string.Empty,
                Platform = request.Browser.Platform,
                FirstRequest = DateTime.Now,
                LastRequest = DateTime.Now
            };
        }

        public void RepeatRequest()
        {
            Count += 1;
            LastRequest = DateTime.Now;
        }
    }
}
