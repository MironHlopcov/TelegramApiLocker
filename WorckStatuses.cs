using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramApiLocker
{
    internal enum WorckStatuses
    {
        started=1,
        inicialisacion = 2,
        finished = 4,
        running =3,
        error=5
    }
}