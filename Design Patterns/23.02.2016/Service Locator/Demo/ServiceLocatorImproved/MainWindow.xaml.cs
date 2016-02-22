using System;
using System.Windows;
using ServiceLocatorDemo;

namespace ServiceLocatorImproved
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private LoggingClass log = ServiceLocator.GetService<LoggingClass>();
		public MainWindow()
		{
			InitializeComponent();
			this.textBlock1.Text = string.Empty;
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string msg = "Button 1 Clicked";
			this.textBlock1.Text += msg + Environment.NewLine;
			log.Log(msg);
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			string msg = "Button 2 Clicked";
			this.textBlock1.Text += msg + Environment.NewLine;
			log.Log(msg);
		}
	}
}
