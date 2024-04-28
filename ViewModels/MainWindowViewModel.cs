using cloud_observer.MVVM;
using cloud_observer.UserControls;
using RecentFileFinder;
using System.Collections.ObjectModel;
using System.IO;

namespace cloud_observer.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		public ObservableCollection<StatusControl> StatusControls { get; set; }

		public MainWindowViewModel()
		{
			// Instantiate new StatusControl list
			StatusControls = new ObservableCollection<StatusControl>();

			string folderPath = GetFolderPath();

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
		}

		static string GetFolderPath() => MainWindow.ROOT_PATH;

		private void SearchFolder(string folderPath)
		{
			// Get list of subfolders
			var subfolders = Directory.GetDirectories(folderPath);

			foreach (var subfolder in subfolders)
			{
				var di = new DirectoryInfo(subfolder);
				var sc = new StatusControl(new OutdatedFolder(di));
				StatusControls.Add(sc);
				SearchFolder(subfolder);
			}

			var files = Directory.GetFiles(folderPath);

			if (files.Length == 0)
			{
                Console.WriteLine($"{folderPath} doesn't contain any files.");
				return;
            }

			// Get most recent file of folder
			var mrf = files
				.Select(file => new FileInfo(file))
				.OrderByDescending(file => file.CreationTime)
				.FirstOrDefault();

		}

	}
}
