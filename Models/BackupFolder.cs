using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cloud_observer.Models
{
	class BackupFolder : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private string _folderPath;
		private DateTime _lastBackupDate;

		public string FolderPath
		{
			get { return _folderPath; }
			set
			{
				_folderPath = value;
				OnPropertyChanged();
			}
		}

		public DateTime LastBackupDate
		{
			get { return _lastBackupDate; }
			set
			{
				_lastBackupDate = value;
				OnPropertyChanged();
			}
		}

		public bool IsUptoDate => (DateTime.Now - _lastBackupDate).TotalDays <= 1;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
