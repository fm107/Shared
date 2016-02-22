using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using log4net;
using log4net.Config;

namespace ServiceLocatorAdvanced
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			XmlConfigurator.Configure();

			//ServiceLocator.AddService<ILog>("logger", new LoggingClass());
			ServiceLocator.RegisterServiceFromAppSettings("logger");
		}

	}
}
