using Newtonsoft.Json;
using ParsingWebService.Class;
using ParsingWebService.Class.MVVM;
using System;
using System.Windows;



namespace ParsingWebService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           DataContext = new ApplicationViewNumber();
            //DataContext = new ApplicationViewKurs();
        }
    }
}
