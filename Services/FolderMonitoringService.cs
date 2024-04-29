using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud_observer.Services
{
    class FolderMonitoringService
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        // Event to notify the ViewModel
        public EventHandler FolderChanged;

        public FolderMonitoringService(string folderPath)
        {
            _fileSystemWatcher = new FileSystemWatcher(folderPath)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };

            // Subscribe to events
            _fileSystemWatcher.Created += OnFolderChanged;
            _fileSystemWatcher.Changed += OnFolderChanged;
			_fileSystemWatcher.Deleted += OnFolderChanged;
		}

		private void OnFolderChanged(object sender, FileSystemEventArgs e)
		{
			FolderChanged?.Invoke(this, EventArgs.Empty);
		}

        public void Dispose()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Created -= OnFolderChanged;
            _fileSystemWatcher.Changed -= OnFolderChanged;
            _fileSystemWatcher.Deleted -= OnFolderChanged;
            _fileSystemWatcher.Dispose();
        }
	}
}
