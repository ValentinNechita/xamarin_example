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
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace SampleCarousel2017App.WPF {
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : WindowsPage {
        public MainPage() {
            InitializeComponent();
            LoadApplication(new SampleCarousel2017App.App());
        }
    }
}
