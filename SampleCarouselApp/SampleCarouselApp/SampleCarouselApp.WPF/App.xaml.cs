using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Xamarin.Forms;
	using Xamarin.Forms.Platform.WPF;
	
namespace SampleCarouselApp.WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application {
        /// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App() {
			Xamarin.Forms.Forms.Init("INSERT-LICENSE-HERE");
		}
    }
}
