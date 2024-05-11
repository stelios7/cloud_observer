using cloud_observer.UserControls;
using cloud_observer.ViewModel;
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
		//public static readonly string ROOT_PATH = @"C:\Users\paokf\Documents\cloudbackup";
		public static readonly string ROOT_PATH = @"\\Seldi_nas\cloudbackup";

		public MainWindow()
		{
			InitializeComponent();
			MainWindowViewModel vm = new MainWindowViewModel();
			this.DataContext = vm;
		}
	}
}