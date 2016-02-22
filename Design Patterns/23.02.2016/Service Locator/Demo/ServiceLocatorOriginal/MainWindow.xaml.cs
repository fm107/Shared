using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace ServiceLocatorDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.textBlock1.Text = string.Empty;
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string msg = "Button 1 Clicked";
			this.textBlock1.Text += msg + Environment.NewLine;
			LogUserActions(msg);
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			string msg = "Button 2 Clicked";
			this.textBlock1.Text += msg + Environment.NewLine;
			LogUserActions(msg);
		}

		private StreamWriter logFile;
		private void LogUserActions( string txt)
		{
			if (logFile == null)
			{
				logFile = new StreamWriter("actions.log");
			}
			logFile.WriteLine(txt);
			logFile.Flush();
		}
	}
}
