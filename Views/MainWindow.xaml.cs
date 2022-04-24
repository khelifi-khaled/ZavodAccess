using System.Windows;
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
            MainVM.CheckIn(TXT_immatriculationIn.Text);
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainVM.CheckOut(TXT_immatriculationOut.Text);
        }
    }
}
