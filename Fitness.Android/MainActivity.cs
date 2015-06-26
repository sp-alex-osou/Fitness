using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Fitness.Shared;

namespace Fitness.Android
{
	[Activity (Label = "Fitness.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			AuthenticationManager.Init();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += async delegate {
				button.Text = "sending request...";
				var success = await AuthenticationManager.Register("alex@osou.at", "yeah");

				button.Text = success ? "yeah!" : "meh :(";
				//button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


