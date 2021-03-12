#define WITHADS             //  Commenting this builds app without ads
#define WITHMAP             //  Commenting this builds without map
//#define BUTTON              //  Commenting this out eliminated "load map" 
                            //     button and loads map immediately


using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;



namespace AdTest
{
    public partial class MainPage : ContentPage
    {
        Map map;
        AdMobView adMobView;
        public string AdUnitId { get; set; }

        public MainPage()
        {

            InitializeComponent();

#if WITHADS
            InitializeAds();
#endif

#if WITHMAP
#if BUTTON
            mapButton.Clicked += onMapButton;
#else
            InitializeMap();
            mapButton.IsVisible = false;
#endif
#endif

        }

        public void onMapButton(object s, EventArgs e)
        {
            mapButton.IsVisible = false;
            InitializeMap();
        }

        public string GetAdUnitID()
        {
            string Id=null;
            if (Device.RuntimePlatform == Device.iOS)
            {
                Id = "ca-app-pub-3940256099942544/2934735716";
            }
            else if (Device.RuntimePlatform == Device.Android)
                {
                    Id = "ca-app-pub-3940256099942544/6300978111";
                }
            return Id;
        }


        public void InitializeAds()
        {
            AdUnitId = GetAdUnitID();

            adMobView = new AdMobView { AdUnitId = this.AdUnitId, HeightRequest=50};

            adStack.Children.Add(adMobView);
        }

        public void InitializeMap()
        {
            map = new Map();
            mapStack.Children.Add(map);
        }
    }
}
