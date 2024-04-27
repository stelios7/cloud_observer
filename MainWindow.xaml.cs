using cloud_observer.UserControls;
using RecentFileFinder;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace cloud_observer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region VARIABLES

		#region GLOBAL
		private static readonly string ROOT_PATH = @"\\Seldi_nas\cloudbackup";
		private static readonly TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(5);
		#endregion GLOBAL

		private static Dictionary<string, List<OutdatedFolder>> OutdatedFolders;
		private DispatcherTimer _timer;
		#endregion

		public MainWindow()
		{
			InitializeComponent();

			SetupTimer();

			Start();

		}

		#region FUNCTIONS

		private void Start()
		{
			string folderPath = GetFolderPath();
			OutdatedFolders = new Dictionary<string, List<OutdatedFolder>>();

			if (!Directory.Exists(folderPath))
			{
				Console.WriteLine($"The folder '{folderPath}' does not exist.");
				return;
			}

			// Get CLOUDBACKUP subfolders
			var subFolders = Directory.GetDirectories(folderPath);
			foreach (var subfolder in subFolders)
			{
				SearchFolder(subfolder);
			}


			MainStackPanel.Children.Clear();
			LastUpdateTimeLabel.Content = DateTime.Now.ToString("hh:mm:ss tt");
			foreach (var item in OutdatedFolders)
			{
				foreach (var c in item.Value)
				{
					UpdateStatusControl(c);

				}
			}
		}

		private void UpdateStatusControl(OutdatedFolder c)
		{
			var uc = new StatusControl();
			uc.SetName($"ΑΦΜ: {c.Name}");
			uc.SetSoftware($"Software: {c.Software}");
			uc.SetInfo($"{c.DaysElapsed} ημέρες.");
			uc.SetStatus(c.IsOutdated);
			MainStackPanel.Children.Add(uc);
		}

		private void SetupTimer()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = TIMER_INTERVAL;
			_timer.Tick += OnTimerTick;
			_timer.Start();
		}

		private void OnTimerTick(object? sender, EventArgs e) => Start();

		private static void SearchFolder(string folderPath)
		{
			// Get list of subfolders
			var subfolders = Directory.GetDirectories(folderPath);

			foreach (var subfolder in subfolders)
			{
				var di = new DirectoryInfo(subfolder);
				var name = di.Name;

				var item = new OutdatedFolder(di);
				if (!OutdatedFolders.ContainsKey(name)) OutdatedFolders.TryAdd(name, new List<OutdatedFolder> { item });

				else OutdatedFolders[name].Add(item);

				SearchFolder(subfolder);
			}
		}

		static string GetFolderPath()
		{
			// Console.Write("Enter the folder path: \n");
			// return Console.ReadLine();
			return ROOT_PATH;
		}

		private void GoToTray_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ClearWrapPanel_Click(object sender, RoutedEventArgs e)
		{
			MainStackPanel.Children.Clear();
		}

		#endregion

	}
}