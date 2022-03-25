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
    internal class AsyncWorck : Thread
    {
        private Handler _handler;
        WorckStatuses result = WorckStatuses.inicialisacion;
        static readonly string TAG = typeof(AsyncWorck).FullName;

        public AsyncWorck(Handler handler)
        {
            _handler = handler;
           
    }
        public void run()
        {
            Thread.Sleep(100000);
            _handler.SendEmptyMessage((int)WorckStatuses.started);
            Thread.Sleep(100000);
            _handler.SendEmptyMessage((int)WorckStatuses.running);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
            Thread.Sleep(100000);
        }
       
    }
}