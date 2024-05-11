﻿using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace RecentFileFinder
{
	public class OutdatedFolder : INotifyPropertyChanged
	{
		public OutdatedFolder(DirectoryInfo di)
		{
			this.fullPath = di.FullName;
			this.name = di.Name;
			this.lastWriteTime = GetLastWriteTime(di);
			this.daysElapsed = DaysFromLastUpload(lastWriteTime);
			this.software = di.Parent.Name;
			System.Console.WriteLine($"Folder: {this.name,9} Last modified at: {lastWriteTime.ToString("dd/MM/yyyy"),11} {daysElapsed,3} days ago.");
		}

		#region PROPERTIES
		private string fullPath;
		public string FullPath
		{
			get { return fullPath; }
			set { fullPath = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private DateTime lastWriteTime;
		public DateTime LastWriteTime
		{
			get { return lastWriteTime; }
			set { lastWriteTime = value; }
		}
		private int daysElapsed;
		public int DaysElapsed
		{
			get { return daysElapsed; }
			set { daysElapsed = value; }
		}
		private bool isOutdated;

		public bool IsOutdated
		{
			get { return daysElapsed < 1; }
		}

		private string software;

		public string Software
		{
			get { return software; }
			set { software = value; }
		}
		private string parent;

		public event PropertyChangedEventHandler? PropertyChanged;

		public string Parent
		{
			get { return parent; }
			set { parent = value; }
		}

		#endregion

		#region FUNCTIONS
		static DateTime GetLastWriteTime(DirectoryInfo di)
		{
			return Directory.GetFiles(di.FullName)
				.Select(file => new FileInfo(file))
				.OrderByDescending(fileInfo => fileInfo.CreationTime)
				.FirstOrDefault().CreationTime;
		}

		static int DaysFromLastUpload(DateTime dt) => (int)(DateTime.Now - dt).TotalDays;

		#endregion
	
	}
}