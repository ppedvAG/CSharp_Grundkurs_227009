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

namespace M014;

public partial class MainWindow : Window
{
	int Counter = 0;

	public MainWindow()
	{
		InitializeComponent();
		CB.ItemsSource = new List<string>() { "C1", "C2", "C3" };
		LB.ItemsSource = new List<string>() { "L1", "L2", "L3" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		TB.Text = (++Counter).ToString();

		Window1 w = new Window1();
		//w.Show();
		bool b = w.ShowDialog() == true;
		if (b)
		{
			//Erfolg
		}
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = $"Element ausgewählt: {CB.SelectedItem}";
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<string>());
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		if (sender is RadioButton rb)
			TB.Text = rb.Content + " gecheckt";
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		if (sender is RadioButton rb)
			TB.Text = rb.Content + " ungecheckt";
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult mbr = MessageBox.Show("Möchtest du wirklich beenden?", "Wirklich beenden?", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (mbr == MessageBoxResult.Yes)
			Environment.Exit(0);
	}
}
