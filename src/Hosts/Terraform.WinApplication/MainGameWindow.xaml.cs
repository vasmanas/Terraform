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
using Terraform.WinApplication.ViewModels;

namespace Terraform.WinApplication
{
    /// <summary>
    /// Interaction logic for MainGameWindow.xaml
    /// </summary>
    public partial class MainGameWindow : Window
    {
        private MainGameViewModel viewModel = new MainGameViewModel();

        public MainGameWindow()
        {
            InitializeComponent();

            this.viewModel.LoadJobs();

            this.DataContext = this.viewModel;
        }
    }
}
