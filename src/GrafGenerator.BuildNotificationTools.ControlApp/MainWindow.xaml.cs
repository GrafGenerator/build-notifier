using System.Windows;
using GrafGenerator.BuildNotificationTools.ControlApp.ViewModel;

namespace GrafGenerator.BuildNotificationTools.ControlApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Initializes a new instance of the MainWindow class.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			Closing += (s, e) => ViewModelLocator.Cleanup();
		}
	}
}