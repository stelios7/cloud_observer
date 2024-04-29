using RecentFileFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cloud_observer.UserControls
{
	/// <summary>
	/// Interaction logic for StatusControl.xaml
	/// </summary>
	public partial class StatusControl : UserControl
	{
		public StatusControl(OutdatedFolder odf)
		{
			InitializeComponent();
			//SetName(odf.Name);
			//SetInfo(odf.DaysElapsed.ToString());
			//SetSoftware(odf.Software);
			//SetStatus(odf.IsOutdated);
		}
		//public void SetName(string name) => labelName.Content = name;
		//public void SetInfo(string info) => labelInfo.Content = info;
		//public void SetSoftware(string soft) => labelSoftware.Content = soft;
		//public void SetStatus(bool isCriteriaMet) => elStatus.Fill = isCriteriaMet ? Brushes.Green : Brushes.Red;
	}
}
