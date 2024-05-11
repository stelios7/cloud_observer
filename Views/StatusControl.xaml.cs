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
		//public static readonly DependencyProperty FolderNameProperty = DependencyProperty.Register("FolderName", typeof(string), typeof(StatusControl));
		//public static readonly DependencyProperty LastBackupDateProperty = DependencyProperty.Register("LastBackupDate", typeof(DateTime), typeof(StatusControl));
		//public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(StatusControl));

		public StatusControl()
		{
			InitializeComponent();
		}

		//public string FolderName
		//{
		//	get { return (string)GetValue(FolderNameProperty); }
		//	set { SetValue(FolderNameProperty, value); }
		//}

		//public DateTime LastBackupDate
		//{
		//	get { return (DateTime)GetValue(LastBackupDateProperty); }
		//	set { SetValue(LastBackupDateProperty, value); }
		//}

		//public Brush BackgroundColor
		//{
		//	get { return (Brush)GetValue(BackgroundColorProperty); }
		//	set { SetValue(BackgroundColorProperty, value); }
		//}

	}
}
