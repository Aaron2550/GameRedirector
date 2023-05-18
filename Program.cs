using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GameRedirector;

internal partial class Program {

	[LibraryImport("kernel32.dll")]
	private static partial IntPtr GetConsoleWindow();

	[LibraryImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static partial bool ShowWindow(IntPtr hWnd, int nCmdShow);

	static void Main(string[] Arguments) {
		if (Arguments.Length == 0) {
			Console.WriteLine("It seems like your Steam Command Line Arguments are not set up correctly. Please check and try again!");
			Console.WriteLine("Set your Steam Arguments like this: '<Game Path> <Directory> <Arguments>'. The Directory and Arguments are optional.");
			Console.WriteLine("Example: '\"D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\hl2.exe\" \"D:\\SteamLibrary\\steamapps\\common\\GarrysMod\" \"-noworkshop\"'");
			Console.WriteLine("Press Enter to exit.");
			Console.ReadLine();
			return;
		}

		string ExecutablePath = Arguments[0];
		string Directory = Arguments.ElementAtOrDefault(1) ?? Path.GetDirectoryName(ExecutablePath)!;
		string ArgumentString = string.Join(' ', Arguments.Skip(2));

		Process GameProcess = new() {
			StartInfo = {
				FileName = ExecutablePath,
				UseShellExecute = true,
				WorkingDirectory = Directory,
				Arguments = ArgumentString
			}
		};

		Console.WriteLine($"Starting '{ExecutablePath}' in '{Directory}' with Arguments '{ArgumentString}'...");
		GameProcess.Start();

		Thread.Sleep(5000);
		ShowWindow(GetConsoleWindow(), 0);

		GameProcess.WaitForExit();
	}
}
