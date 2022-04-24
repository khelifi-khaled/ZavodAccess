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
using ZavodAccess.ViewModels;

namespace ZavodAccess.Views
{
      
   


    public partial class MainWindow : Window
    {


        public MainVM MainVM { get; set; }




        public MainWindow()
        {
            MainVM=new MainVM();
            DataContext=MainVM;
            InitializeComponent();
        }

        private void CheckInBtn_Click(object sender, RoutedEventArgs e)
        {
            MainVM.CheckIn(TXT_immatriculation.Text);
        }
    }
}
