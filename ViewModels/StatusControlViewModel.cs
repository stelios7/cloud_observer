using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud_observer.ViewModels
{
    class StatusControlViewModel
    {
		private string fullPath;
		private string status;
		private string name;
		private int daysElapsed;

		public string FullPath { get => fullPath; set { fullPath = value; } }
		public string Status { get => status; set => status = value; }
		public string Name { get => name; set => name = value; }
		public int DaysElapsed { get => daysElapsed; set => daysElapsed = value; }
		public bool IsOutdated { get; set; }

        public StatusControlViewModel() { 

        }
    }
}
