﻿//using Android.Content;
//using FiveLetters.CustomRenders;
//using Microsoft.Maui.Controls.Compatibility.Platform.Android;
//using Microsoft.Maui.Controls.Platform;

//namespace FiveLetters.Platforms.Android
//{
//    public class AdBanner_Droid : ViewRenderer
//    {
//        Context context;
//        public AdBanner_Droid(Context _context) : base(_context)
//        {
//            context = _context;
//        }
//        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
//        {
//            base.OnElementChanged(e);
//            if (e.OldElement == null)
//            {
//                var adView = new AdView(Context);
//                switch ((Element as AdBanner).Size)
//                {
//                    case AdBanner.Sizes.Standardbanner:
//                        adView.AdSize = AdSize.Banner;
//                        break;
//                    case AdBanner.Sizes.LargeBanner:
//                        adView.AdSize = AdSize.LargeBanner;
//                        break;
//                    case AdBanner.Sizes.MediumRectangle:
//                        adView.AdSize = AdSize.MediumRectangle;
//                        break;
//                    case AdBanner.Sizes.FullBanner:
//                        adView.AdSize = AdSize.FullBanner;
//                        break;
//                    case AdBanner.Sizes.Leaderboard:
//                        adView.AdSize = AdSize.Leaderboard;
//                        break;
//                    case AdBanner.Sizes.SmartBannerPortrait:
//                        adView.AdSize = AdSize.SmartBanner;
//                        break;
//                    default:
//                        adView.AdSize = AdSize.Banner;
//                        break;
//                }
//                // TODO: change this id to your admob id  
//                adView.AdUnitId = "ca-app-pub-3722188479346998/5249705794";
//                var requestbuilder = new AdRequest.Builder();
//                adView.LoadAd(requestbuilder.Build());
//                SetNativeControl(adView);
//            }
//        }
//    }
//}
