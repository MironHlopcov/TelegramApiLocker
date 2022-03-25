using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramApiLocker
{
    public static class AlarmSheduller
    {
        public static void AddSheduleAlarm(Context context, Type type, int secondsCount)
        {
            int time = Convert.ToInt32(secondsCount);
            Intent i = new Intent(context, type);
            //PASS CONTEXT,YOUR PRIVATE REQUEST CODE,INTENT OBJECT AND FLAG
            PendingIntent pi = PendingIntent.GetBroadcast(context, 0, i, 0);
            //INITIALIZE ALARM MANAGER
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            ////SET THE ALARM
            int SDK_KITKAT = (int)Android.OS.BuildVersionCodes.Kitkat;
            int SDK_INT = (int)Build.VERSION.SdkInt;
            if (SDK_INT < SDK_KITKAT)
                alarmManager.Set(AlarmType.RtcWakeup, JavaSystem.CurrentTimeMillis() + (time * 1000), pi);
            else if ((int)Android.OS.BuildVersionCodes.Kitkat <= SDK_INT && SDK_INT < (int)Android.OS.BuildVersionCodes.M)
                alarmManager.SetExact(AlarmType.RtcWakeup, JavaSystem.CurrentTimeMillis() + (time * 1000), pi);
            else if (SDK_INT >= (int)Android.OS.BuildVersionCodes.M)
            {
                alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, JavaSystem.CurrentTimeMillis() + (time * 1000), pi);
            }

        }
    }
    
}