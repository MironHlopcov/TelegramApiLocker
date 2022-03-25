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
using System.Threading;

namespace TelegramApiLocker
{
    class AsyncJob : AsyncTask<string, Java.Lang.Void, WorckStatuses>
    {
        readonly Context context;
        WorckStatuses result = WorckStatuses.inicialisacion;
        static readonly string TAG = typeof(AsyncJob).FullName;

        public AsyncJob(Context context)
        {
            Logger.addText("Assing job started. " + DateTime.Now);
            this.context = context;
        }

        protected override WorckStatuses RunInBackground(params string[] @params)
        {
            //fibonacciValue = -1;
            //long value = @params[0];
            //return GetFibonacciFor(value);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            return result;
        }

        protected override void OnPostExecute(WorckStatuses result)
        {

            base.OnPostExecute(result);
            Logger.addText("Finished Job: " + DateTime.Now);
            Log.Debug(TAG, "Finished Job: " + result);

        }

        protected override void OnCancelled()
        {
            Log.Debug(TAG, "Job was cancelled.");
            Logger.addText("Job was cancelled. " + DateTime.Now);
            //jobService.BroadcastResults(-1);
            base.OnCancelled();
        }

    }
}