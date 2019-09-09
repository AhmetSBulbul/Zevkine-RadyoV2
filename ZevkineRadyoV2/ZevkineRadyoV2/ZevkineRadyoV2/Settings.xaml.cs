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
using System.Windows.Shapes;

namespace ZevkineRadyoV2
{
    /// <summary>
    /// Settings.xaml etkileşim mantığı
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		DutyMan duty = new DutyMan();
		private string name, baseFrequency;

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			name = txtName.Text;
			baseFrequency = txtBaseFrequency.Text;
			duty.Add(name, baseFrequency);
			txtName.Clear();
			txtBaseFrequency.Clear();
			Refresh();
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			name = txtName.Text;
			duty.Delete(name);
			txtName.Clear();
			txtBaseFrequency.Clear();
			Refresh();
		}

		private void DataGridRadioList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dataGridRadioList.SelectedItem != null)
			{
				txtName.Text = (((TextBlock)dataGridRadioList.Columns[0].GetCellContent(dataGridRadioList.SelectedItem)).Text);
				txtBaseFrequency.Text = (((TextBlock)dataGridRadioList.Columns[1].GetCellContent(dataGridRadioList.SelectedItem)).Text);
			}
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			Refresh();
		}

		private void Refresh()
		{
			dataGridRadioList.ItemsSource = duty.Fill().DefaultView;
		}
	}
}
