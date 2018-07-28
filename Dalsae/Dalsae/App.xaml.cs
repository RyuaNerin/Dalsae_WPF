using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using SharpRaven;
using SharpRaven.Data;
using static Dalsae.DalsaeManager;
using static Dalsae.DataManager;
using static Dalsae.FileManager;

namespace Dalsae
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
	{
		public App()
		{
			this.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
			this.Dispatcher.UnhandledExceptionFilter += Dispatcher_UnhandledExceptionFilter;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

			DataInstence.Init();
			FileInstence.Init();//init
			DalsaeInstence.Init();//init
		}

		private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			e.SetObserved();
			SendException(e.Exception);
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			SendException((Exception)e.ExceptionObject);
		}

		private void Dispatcher_UnhandledExceptionFilter(object sender, DispatcherUnhandledExceptionFilterEventArgs e)
		{
			SendException(e.Exception);
		}

		private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			e.Handled = true;
			SendException(e.Exception);
		}

		public static void SendException(Exception e)
		{
			SendSentry(new SentryEvent(e));
		}

		public void SendException(string msg)
		{
			SendSentry(new SentryEvent(new SentryMessage(msg)));
		}

		public void SendException(SentryMessage msg)
		{
			SendSentry(new SentryEvent(msg));
		}

		public static void SendException(string msg, string json)
		{
			Exception ex = new Exception(msg);
			ex.Data.Add("data", json);
			SendSentry(new SentryEvent(ex));
		}

		public static void SendSentry(SentryEvent sentry)
		{
			if (DataInstence?.option?.isSendError == false) return;
			RavenClient ravenClient = new RavenClient("https://4d47f583a98748cfafb1ce90eb41844f:c9c950b43eb24cbb9a47b199e11cfa93@sentry.io/1191534");
			ravenClient.Capture(sentry);
		}
	}
}
