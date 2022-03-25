using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramApiLocker.Services;

namespace TelegramApiLocker
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class MyReceiver : BroadcastReceiver
    {
        static readonly string TAG = typeof(MyReceiver).FullName;
        Intent startServiceIntent;

        public override void OnReceive(Context context, Intent intent)
        {
            ////Toast.MakeText(context, "Alarm Ringing!", ToastLength.Short).Show();
            Logger.addText("Alarm Ringing! " + DateTime.Now);
            StartForegroundService(context);
        }

        private void StartForegroundService(Context context)
        {
            startServiceIntent = new Intent(context, typeof(ForegroundService));
            startServiceIntent.SetAction(Constants.ACTION_START_SERVICE);

            context.StartService(startServiceIntent);
            Logger.addText("User requested that the service be started. " + DateTime.Now);
            ////Log.Info(TAG, "User requested that the service be started.");

        }
    }
}