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

namespace PRPR4
{
    /// <summary>
    /// Логика взаимодействия для EntityFrameworkWindow.xaml
    /// </summary>
    public partial class EntityFrameworkWindow : Window
    {
        private Cinema_practicEntities context = new Cinema_practicEntities();
        public EntityFrameworkWindow()
        {
            InitializeComponent();

            AllDataGrid.ItemsSource = context.Movies.ToList();
            AllCombobox.ItemsSource = context.Films.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = context.Movies.ToList().Where(x => x.Age_Rating.Contains(SearchTxt.Text));
            AllCombobox.ItemsSource = context.Films.ToList();
        }   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AllDataGrid.ItemsSource = context.Movies.ToList();
        }
        private void AllCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllCombobox.SelectedItem != null)
            {
                var selected = AllCombobox.SelectedItem as Films;
                AllDataGrid.ItemsSource = context.Movies.ToList().Where(x => x.Film_ID == selected.ID_Films);
            }
        }
    }
}
