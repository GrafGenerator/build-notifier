using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace GrafGenerator.BuildNotificationTools.ControlApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		static App()
		{
			DispatcherHelper.Initialize();
		}
	}
}
