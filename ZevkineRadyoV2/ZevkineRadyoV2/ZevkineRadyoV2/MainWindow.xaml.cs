using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ZevkineRadyoV2
{
	/// <summary>
	/// MainWindow.xaml etkileşim mantığı
	/// </summary>
	public partial class MainWindow : Window
	{
		DutyMan dutyMan = new DutyMan();
		


		public MainWindow()
		{
			InitializeComponent();
			 

		}
		
		private void FillComboBox()
		{
			List<string> names = new List<string>();
			names = dutyMan.Populate();
			foreach(string name in names)
			{
				comboBoxName.Items.Add(name);
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			Application.Current.Shutdown();
		}

		private void Question_Click(object sender, RoutedEventArgs e)
		{
			

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			
			FillComboBox();
			
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{
			string basename = comboBoxName.SelectedItem.ToString();
			Player.Source = new Uri(dutyMan.GiveTheMusic(basename));
			Player.Play();
		}

		private void PlayerStop_Click(object sender, RoutedEventArgs e)
		{
			
			Player.Stop();
		}

		private void BtnSettings_Click(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.ShowDialog();
		}
	}
}
