﻿using System;
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

namespace CareService.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.EmployeeListViewModel();
        }

        private void ViewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new EmployeeView((sender as Button).DataContext as Models.Employee));
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new EmployeeView(null));
        }
    }
}
