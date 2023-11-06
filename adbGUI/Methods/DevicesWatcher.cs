using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace adbGUI.Methods
{
	static class DevicesWatcher
	{
		public static event EventHandler<List<string>> DevicesChanged;
		public static List<string> Devices;

		private static string oldOutput = "";

		private static readonly Thread thread;

		private static int refreshInterval;

		static DevicesWatcher()
		{
			thread = new Thread(new ThreadStart(Refresh));
		}

		public static void Refresh()
		{
			while (true)
			{
				string output = CLI.GetOutput("adb", "devices");

				if (output != oldOutput)
				{
					Devices = Devices ?? new List<string>();
					Devices.Clear();

					oldOutput = output;

					foreach (string str in output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (str.StartsWith("List"))
						{
							continue;
						}

						Devices.Add(str.Substring(0, str.IndexOf("\t")));

						Debug.WriteLine("Device added: " + str.Substring(0, str.IndexOf("\t")));
					}

					DevicesChanged?.Invoke(null, Devices);
				}
				Thread.Sleep(refreshInterval);
			}
		}

		public static void Start(int interval = 2000)
		{
			refreshInterval = interval;
			thread.Start();
			Debug.WriteLine($"DeviceWatcher thread{thread.ManagedThreadId} started");
		}
	}

}
