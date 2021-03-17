# AdMapsCrash
minimal code to demonstrate Google Ads/Maps Crash on Android 10+


I’ve written an app that uses both Xamarin.Forms Maps and Admob.  It attempts to display both 
a map and a banner ad on the main page.  I’ve used typical admob renderers for iOS and Android 
that I’ve found online.  The app works fine on iOS, but it crashes on Android when, just as the 
ad displays. In the device log and output screen, it indicates a fatal SIGSEGV, just after 
the ad loads:

BannerListener: the Ad has loaded
[libc] Fatal signal 11 (SIGSEGV), code 1 (SEGV_MAPERR), fault addr 0x0 in tid 20590(RenderThread), pid 20544 (com.AdTest)

If I eliminate either the map, or the ad, the other works fine.  It’s only when both views try
to load at the same time that it crashes, and it crashes on Android 11 and 10, but not 9 or 8.  
The build targets 11.   I’ve tested primarily on emulators, but I’ve tried a physical Android 8 
device, and it works fine.  

I’ve written a minimal project to demonstrate this.  
It’s on github at https://github.com/ighill/AdMapsCrash

The project includes the testads app_id and ad_id, but not a google maps api_key.  You’ll have 
to add your own to the manifest file, although it seems to crash even with nonsense in place of 
the api_key – it just leaves the map blank.

Note that I add the two views programmatically in MainPage.xaml.cs, but it behaves exactly the 
same if they are defined in xaml.

Also, if I delay the loading of the map by including a button that triggers the map to load, 
and I press it after the ad appears, the map loads fine, and it will continue to run, updating 
the ad periodically.

At the top of MainPage.xaml.cs, I have three compiler directives, WITHADS, WITHMAP and BUTTON 
that control whether each is included.  If BUTTON is not defined, and WITHMAP is, the map loads 
immediately (and crashes, if WITHADS is also defined).

I’m using Visual Studio 2019, with the most recent updates installed, and the following nuget 
package versions (all up to date as of this writing):

NetStandard.Library v2.0.3
Xamarin.Build.Download v0.10.0
Xamarin.Essentials v1.6.1
Xamarin.Forms v5.0.0.2012
Xamarin.Forms.Maps v5.0.0.2012
Xamarin.GooglePlayServices.Ads v119.7.0

Note that I’ve also tried it with the same version of Xamarin.Firebase.Ads, with the same results.  
Also, I’ve gone through a number of iterations of downgraded admob packages and corresponding 
Forms/Forms.Maps versions, with exactly the same results.

The github repository includes a file, output.txt, that contains the device.log output from a 
crashed run.

Thanks in advance.  I hope someone can give me some insight into what I’m doing wrong!

