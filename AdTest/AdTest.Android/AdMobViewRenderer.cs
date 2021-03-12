using Android.Content;
using Android.Widget;
using System;
using Xamarin.Forms;
using AdTest;
using AdTest.Droid;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace AdTest.Droid
{
	public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>
	{
		public AdMobViewRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null && Control == null)
				SetNativeControl(CreateAdView());
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == nameof(AdView.AdUnitId))
				Control.AdUnitId = Element.AdUnitId;
		}

		private AdView CreateAdView()
		{
			var adView = new AdView(Context)
			{
				AdSize = AdSize.Banner,
				AdUnitId = Element.AdUnitId
			};

			adView.AdListener = new BannerListener();

			adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

			adView.LoadAd(new AdRequest.Builder().Build());
			return adView;
		}
	}


	public class BannerListener:AdListener
	{

		public override void OnAdLoaded()
		{
			Console.WriteLine("BannerListener: the Ad has loaded");
		}
		public override void OnAdFailedToLoad(LoadAdError p0)
		{
			Console.WriteLine("BannerListener: Ad Failed with code " + p0.Message);
		}
	}
}