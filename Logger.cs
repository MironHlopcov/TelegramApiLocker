using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TelegramApiLocker
{
    static internal class Logger
    {
        static readonly string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Log.txt");
        public static void addText(string text)
        {
            File.AppendAllText(fileName, text);
        }
        public static string getFileName()
        {
            return fileName;
        }
        
    }
}