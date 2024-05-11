using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace cloud_observer.ViewModels
{
	class StatusControlViewModel : INotifyPropertyChanged
	{
		#region INotify implementation

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		#region Properties

		private string _lastBackup;
		private int _daysElapsed;
		private string _software;
		private string _afm;

		public string LastBackup
		{
			get { return _lastBackup; }
			set
			{
				_lastBackup = value;
				OnPropertyChanged();
			}
		}
		public int DaysElapsed
		{
			get { return _daysElapsed; }
			set
			{
				_daysElapsed = value;
				OnPropertyChanged();
			}
		}
		public string Software
		{
			get { return _software; }
			set
			{
				_software = value;
				OnPropertyChanged();
			}
		}
		public string AFM
		{
			get { return _afm; }
			set
			{
				_afm = value;
				OnPropertyChanged();
			}
		}

		public Brush EllipseBackgroundColor { get => DaysElapsed >= 1 ? Brushes.Red : Brushes.Green; }

        #endregion

        public StatusControlViewModel(DirectoryInfo info)
        {
			this.DaysElapsed = GetDaysElapsed(info);
			this.Software = info.Parent.Name;
			this.AFM = info.Name;
        }

		private int GetDaysElapsed(DirectoryInfo info)
		{
			var files = info.GetFiles();
			if (files.Length > 0)
			{
				return (DateTime.Now - files.OrderByDescending(file => file.CreationTime).FirstOrDefault().CreationTime).Days;
			}

			return 999;
		}

    }
}
