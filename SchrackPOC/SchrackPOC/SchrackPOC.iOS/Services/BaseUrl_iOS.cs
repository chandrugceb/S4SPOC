using System;
using Foundation;
using SchrackPOC.iOS.Services;
using SchrackPOC.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_iOS))]

namespace SchrackPOC.iOS.Services
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
