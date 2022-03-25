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
	public static class Constants
	{
		public const string APP_NAME = "TelegramApiLocker";
		public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
		public const string NOTIFICATION_NOTIFICATION_CHANELL_NAME = APP_NAME + ".Notification.Chenell.Name";

		public const string SERVICE_STARTED_KEY = "has_service_been_started";
		public const string BROADCAST_MESSAGE_KEY = "broadcast_message";
		public const string NOTIFICATION_BROADCAST_ACTION = APP_NAME + ".Notification.Action";
		
		public const string ACTION_START_SERVICE = APP_NAME + ".action.START_SERVICE";
		public const string ACTION_STOP_SERVICE = APP_NAME + ".action.STOP_SERVICE";
		public const string ACTION_RESTART_TIMER = APP_NAME + ".action.RESTART_TIMER";
		public const string ACTION_MAIN_ACTIVITY = APP_NAME + ".action.MAIN_ACTIVITY";
	}
}