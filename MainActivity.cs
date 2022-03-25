using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Content;
using Java.Lang;
using Android.Widget;
using Android.Util;
using TelegramApiLocker.Services;

namespace TelegramApiLocker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = typeof(MainActivity).FullName;
        public Button startServiceButton;
        Intent startServiceIntent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            startServiceButton = FindViewById<Button>(Resource.Id.start_timestamp_service_button);
            startServiceButton.Click += StartServiceButton_Click;

            setAllarm();
        }

        private void StartServiceButton_Click(object sender, EventArgs e)
        {
            startServiceIntent = new Intent(this, typeof(ForegroundService));
            startServiceIntent.SetAction(Constants.ACTION_START_SERVICE);

            startServiceButton.Enabled = false;
            startServiceButton.Click -= StartServiceButton_Click;

            StartService(startServiceIntent);
            Log.Info(TAG, "User requested that the service be started.");
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void setAllarm()
        {
            AlarmSheduller.AddSheduleAlarm(this, typeof(MyReceiver), 15);
            //Toast.MakeText(this, "Alarm set", ToastLength.Short).Show();
            Logger.addText("Alarm set " + DateTime.Now);
        }
    }
}
