using System;
using System.Collections.Generic;
using System.Data;
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
using PRPR4.Cinema_practicDataSetTableAdapters;

namespace PRPR4
{
    public partial class DataSetWindow : Window
    {
        MoviesTableAdapter movies = new MoviesTableAdapter();
        FilmsTableAdapter films = new FilmsTableAdapter();
        public DataSetWindow()
        {
            InitializeComponent();
            AllDataGrid.ItemsSource = movies.GetData();
            AllCombobox.ItemsSource = films.GetData();
            AllCombobox.DisplayMemberPath = "Name_Film";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTxt.Text != null) 
            {
                AllDataGrid.ItemsSource = movies.SearchByAge_Rating(SearchTxt.Text); 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = movies.GetData();
        }

        private void AllCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllCombobox.SelectedItem != null)
            {
                var id = (int)(AllCombobox.SelectedItem as DataRowView).Row[0];
                AllDataGrid.ItemsSource = movies.FilterbyFilms(id);
            }
        }
    }
}
