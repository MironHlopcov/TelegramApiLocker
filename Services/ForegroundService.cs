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

namespace TelegramApiLocker.Services
{
	[Service]
	public partial class ForegroundService : Service
	{
		Handler handler;
		
		static readonly string TAG = typeof(ForegroundService).FullName;
		bool isStarted;

		public override void OnCreate()
		{
			base.OnCreate();
			Log.Info(TAG, "OnCreate: the service is initializing.");
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			if (intent.Action.Equals(Constants.ACTION_START_SERVICE))
			{
				if (isStarted)
				{
					//Log.Info(TAG, "OnStartCommand: The service is already running.");
					Logger.addText("OnStartCommand: The service is already running. " + DateTime.Now);
				}
				else
				{
					////Log.Info(TAG, "OnStartCommand: The service is starting.");
					Logger.addText("OnStartCommand: The service is starting." + DateTime.Now);
					RegisterForegroundService();
					isStarted = true;
				}
			}
			else if (intent.Action.Equals(Constants.ACTION_STOP_SERVICE))
			{
				//Log.Info(TAG, "OnStartCommand: The service is stopping.");
				Logger.addText("OnStartCommand: The service is stopping. " + DateTime.Now);
				StopForeground(true);
				//StopSelf();
				StopSelfResult(startId);
				isStarted = false;
			}
			else if (intent.Action.Equals(Constants.ACTION_RESTART_TIMER))
			{
				//Log.Info(TAG, "OnStartCommand: Restarting the timer.");
				Logger.addText("OnStartCommand: Restarting the timer. " + DateTime.Now);
			}
			// This tells Android not to restart the service if it is killed to reclaim resources.
			return StartCommandResult.Sticky;
		}


		public override IBinder OnBind(Intent intent)
		{
			// Return null because this is a pure started service. A hybrid service would return a binder that would
			// allow access to the GetFormattedStamp() method.
			return null;
		}


		public override void OnDestroy()
		{
			Log.Info(TAG, "OnDestroy: The started service is shutting down.");
			Logger.addText("OnDestroy: The started service is shutting down. " + DateTime.Now);

			// Remove the notification from the status bar.
			var notificationManager = (NotificationManager)GetSystemService(NotificationService);
			notificationManager.Cancel(Constants.SERVICE_RUNNING_NOTIFICATION_ID);

			isStarted = false;
			base.OnDestroy();
		}

		
		void RegisterForegroundService()
		{
			var myServiceName = typeof(ForegroundService).FullName;
			NotificationChannel chan = new NotificationChannel(myServiceName, Constants.NOTIFICATION_NOTIFICATION_CHANELL_NAME, NotificationImportance.None);
			chan.EnableVibration(false);
			chan.LockscreenVisibility = NotificationVisibility.Secret;

			NotificationManager notificationManager = GetSystemService(NotificationService) as NotificationManager;
			notificationManager.CreateNotificationChannel(chan);

			var notification = new Notification.Builder(this, myServiceName)
			.SetContentTitle(Resources.GetString(Resource.String.app_name))
			.SetContentText(Resources.GetString(Resource.String.notification_text))
			.SetSmallIcon(Resource.Drawable.notification_template_icon_low_bg) //!
			.SetContentIntent(BuildIntentToShowMainActivity())
			.SetOngoing(true)
			.AddAction(BuildRestartTimerAction())
			.AddAction(BuildStopServiceAction())
			.Build();

			goJob();
			
			// Enlist this instance of the service as a foreground service
			StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notification);
		}


		private void goJob()
		{
			//AsyncJob asyncJob = new AsyncJob(this);
			//asyncJob.Execute("");

			handler = new Handler();

			AsyncWorck asyncWorck = new AsyncWorck(handler);
			

			void HandleMessage(Message msg)
			{
				if (msg == null)
					return;
			}
				
		}
		


		/// <summary>
		/// Builds a PendingIntent that will display the main activity of the app. This is used when the 
		/// user taps on the notification; it will take them to the main activity of the app.
		/// </summary>
		/// <returns>The content intent.</returns>
		PendingIntent BuildIntentToShowMainActivity()
		{
			var notificationIntent = new Intent(this, typeof(MainActivity));
			notificationIntent.SetAction(Constants.ACTION_MAIN_ACTIVITY);
			notificationIntent.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTask);
			notificationIntent.PutExtra(Constants.SERVICE_STARTED_KEY, true);

			var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);
			return pendingIntent;
		}

		/// <summary>
		/// Builds a Notification.Action that will instruct the service to restart the timer.
		/// </summary>
		/// <returns>The restart timer action.</returns>
		Notification.Action BuildRestartTimerAction()
		{

			var restartTimerIntent = new Intent(this, GetType());
			restartTimerIntent.SetAction(Constants.ACTION_RESTART_TIMER);
			var restartTimerPendingIntent = PendingIntent.GetService(this, 0, restartTimerIntent, 0);

			var builder = new Notification.Action.Builder(Resource.Drawable.ic_action_restart_timer,
											  GetText(Resource.String.restart_timer),
											  restartTimerPendingIntent);

			return builder.Build();
		}

		/// <summary>
		/// Builds the Notification.Action that will allow the user to stop the service via the
		/// notification in the status bar
		/// </summary>
		/// <returns>The stop service action.</returns>
		Notification.Action BuildStopServiceAction()
		{
			var stopServiceIntent = new Intent(this, GetType());
			stopServiceIntent.SetAction(Constants.ACTION_STOP_SERVICE);
			var stopServicePendingIntent = PendingIntent.GetService(this, 0, stopServiceIntent, 0);

			var builder = new Notification.Action.Builder(Android.Resource.Drawable.IcMediaPause,
														  GetText(Resource.String.stop_service),
														  stopServicePendingIntent);
			return builder.Build();

		}

		
	}
}