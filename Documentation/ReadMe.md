# XamarinWPFSamples

Because Xamarin is about to release WPF,

IndigoOlive.Xamarin.Forms.Platform.WPF is now FREE for commercial use.

The samples in this repository demonstrate how to use the Visual Studio NuGet Package IndigoOlive.Xamarin.Forms.Platform.WPF and the NuGet Package IndigoOlive.Xamarin.Forms.Maps.WPF.

If you are a seasoned developer, the you only need to make sure that the secions below titled: "Modify App.xaml", "Modify App.xaml.cs" and "Add CustomMapRenderer" are completed.  The rest of this should be
second hand, and is just here as a reference.

## Getting Started

### Create the Xamarin.Forms SampleMapsApp

Open Microsoft Visual Studio

![Visual Studio 2017](../images/VS2017.jpg)

Create a new Cross Platform Xamarin App with the name: SampleMapsApp.

![Xamarin New Project](../images/XamarinNewMapsProject.jpg)

Select Master Detail and PCL type project and click Finish.

![Xamarin Selections](../images/XamarinChoice.jpg)

### Add the WPF project

Add a new project to the solution.

![Visual Studio Add New Project](../images/VSAddNewProj.jpg)

To keep the project structure, browse for project location.

If your project is located at C:\MyProjects\SampleMapsApp, the structure will look like:

    C:\MyProjects\SampleMapsApp
    C:\MyProjects\SampleMapsApp\.vs
    C:\MyProjects\SampleMapsApp\packages
    C:\MyProjects\SampleMapsApp\SampleMapsApp
    C:\MyProjects\SampleMapsApp\SampleMapsApp\SampleMapsApp
    C:\MyProjects\SampleMapsApp\SampleMapsApp\SampleMapsApp.Android
    C:\MyProjects\SampleMapsApp\SampleMapsApp\SampleMapsApp.iOS
    C:\MyProjects\SampleMapsApp\SampleMapsApp\SampleMapsApp.UWP
    C:\MyProjects\SampleMapsApp.sln

So, browse to the C:\MyProjects\SampleMapsApp\SampleMapsApp

![Sample App Directory Select image](../images/VSNewMapsWPFLoc.jpg)

Now select C#

Select the Windows Classic Desktop -> WPF App (.NET Framework)

![Visual Studio New Maps WPF](../images/VSNewMapsWPF.jpg)

Give the project the name: SampleMapsApp.WPF

Finally press Ok.

### Add the IndigoOlive.Xamarin.Forms.Platform.WPF Nuget to the WPF Application

Right click the SampleMapsApp.WPF project.

Select Manage Nuget Packages

![Visual Studio Manage NuGet](../images/VSManageNuGet.jpg)

Browse and Install IndigoOlive.Xamarin.Forms.Platform.WPF by John Russell

![Visual Studio Add WPF NuGet](../images/AddXamarinWPF_B.jpg)

Accept the license agreement.

### Modify App.xaml

Open file new project file: App.Xaml

change the code from:

```xml
    <Application x:Class="SampleCarouselApp.WPF.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:SampleCarouselApp.WPF"
                 StartupUri="MainWindow.xaml">
        <Application.Resources>
         
        </Application.Resources>
    </Application>
```

to:

```xml
    <Application x:Class="SampleMapsApp.WPF.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:SampleMapsApp.WPF"
                 StartupUri="MainPage.xaml">
        <Application.Resources>
            <ResourceDictionary Source="Resources.xaml" />
        </Application.Resources>
    </Application>
```

What was changed?

1) MainWindow.xaml was changed to MainPage.xaml

2) Added the line:

```xml
    <ResourceDictionary Source="Resources.xaml" />
```

### Modify App.xaml.cs

Open file new project file: App.Xaml.cs

change the code from:

```C#
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows;

	namespace SampleCarouselApp.WPF
	{
		/// <summary>
		/// Interaction logic for App.xaml
		/// </summary>
		public partial class App : Application
		{
		}
	}
```

to:

```C#
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows;

	using Xamarin.Forms;
	using Xamarin.Forms.Platform.WPF;

	namespace SampleCarouselApp.WPF
	{
		/// <summary>
		/// Interaction logic for App.xaml
		/// </summary>
		public partial class App : System.Windows.Application
		{
			/// <summary>
			/// Initializes the singleton application object.  This is the first line of authored code
			/// executed, and as such is the logical equivalent of main() or WinMain().
			/// </summary>
			public App() {
				Xamarin.Forms.Forms.Init();
			}
		}
	}
```

What was changed?

1) Application was changed to System.Windows.Application

2) public App() {} constructor was added.

3) the contents of the constructor: Xamarin.Forms.Forms.Init("INSERT-LICENSE-HERE");

4) Using Xamarin.Forms and Using Xamarin.Forms.Platform.WPF was added.

### Add a reference

In the SampleMapsApp.WPF right click onto References and select Add...

![Sample Maps App Selection image](../images/SampleMapsAppWPFReferences.jpg)

Then add a reference to the Project in the solution called: SampleApp

![Sample Maps App Reference Select image](../images/SampleMapsAppRef.jpg)

### Set as startup project

Set the SampleMapsApp.WPF as the Start-Up Project for the SampleMapsApp Solution.

### Add CustomMapRenderer

Create an new class called: CustomMapRenderer

Add the following code to that file:

```C#
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Globalization;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using MapControl;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.WPF;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Maps.WPF;
    using System.ComponentModel;

    using SampleMapsApp;
    using SampleMapsApp.WPF;

    [assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
    namespace SampleMapsApp.WPF {
        public class Base : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class Point : Base
        {
            private string name;
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }

            private MapControl.Location location;
            public MapControl.Location Location
            {
                get { return location; }
                set
                {
                    location = value;
                    RaisePropertyChanged("Location");
                }
            }
        }
    
        public class CustomMapRenderer : MapRenderer
        {
            MapControl.Map nativeMap;
            List<CustomPin> customPins;

            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement != null)
                {
                    nativeMap = null;
                }

                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    this.nativeMap = Control as MapControl.Map;
                    this.customPins = formsMap.CustomPins;

                    updateAllPins();
                }
            }

            private void updateAllPins() {
                if (this.customPins != null) {
                    int nOdx = 0;
                    int nCount = 0;

                    nCount = this.customPins.Count;
                    for (nOdx = 0; nOdx < nCount; nOdx++) {
                        string sPinLabel = this.customPins[nOdx].Latitude.ToString("F2").Substring(0, 2);
                        MapControl.Location aLoc = new MapControl.Location(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                        System.Windows.Media.Brush pinBrush = System.Windows.Media.Brushes.Blue;
                        if (this.customPins[nOdx].BluePin) {
                            pinBrush = System.Windows.Media.Brushes.Blue;
                        } else {
                            /** Orange Push Pin */
                            pinBrush = System.Windows.Media.Brushes.Orange;
                        }

                        ObservableCollection<Point> somePushpins = new ObservableCollection<Point>();

                        /**
                         * From Xaml Map Control github code (codeplex)
                         *  Pushpins = new ObservableCollection<Point>();
                            Pushpins.Add(
                                new Point
                                {
                                    Name = "WHV - Eckwarderh�rne",
                                    Location = new Location(53.5495, 8.1877)
                                });
                         **/

                        Point aPushPin = new Point {
                            Name = sPinLabel,
                            Location = new MapControl.Location(aLoc.Latitude, aLoc.Longitude)
                        };

                        System.Windows.Style style = new System.Windows.Style {TargetType = typeof(MapItem) };
                        style.Setters.Add(new System.Windows.Setter( MapPanel.LocationProperty, aLoc));
                        style.Setters.Add(new System.Windows.Setter( MapItem.VerticalContentAlignmentProperty, System.Windows.VerticalAlignment.Bottom ));
                        style.Setters.Add(new System.Windows.Setter( MapItem.ForegroundProperty, System.Windows.Media.Brushes.Black));
                        style.Setters.Add(new System.Windows.Setter( MapItem.BackgroundProperty, pinBrush));
                        style.Setters.Add(new System.Windows.Setter( MapItem.VisibilityProperty, System.Windows.Visibility.Visible));
                        System.Windows.FrameworkElementFactory aPin = new FrameworkElementFactory(typeof(MapControl.Pushpin));
                        aPin.SetValue(MapControl.Pushpin.ContentProperty, sPinLabel);
                        aPin.SetValue(MapControl.Pushpin.ForegroundProperty, System.Windows.Media.Brushes.Black);
                        aPin.SetValue(MapControl.Pushpin.BackgroundProperty, pinBrush);
                        System.Windows.Controls.ControlTemplate ct = new System.Windows.Controls.ControlTemplate(typeof(MapControl.MapItem));
                        ct.VisualTree = aPin;
                        style.Setters.Add(new System.Windows.Setter( MapItem.TemplateProperty, ct));

                        somePushpins.Add(aPushPin);

                        MapControl.MapItemsControl aControl = new MapItemsControl {
                            ItemsSource = somePushpins,
                            ItemContainerStyle = style,
                            IsSynchronizedWithCurrentItem = true
                        };

                        Control.Children.Add(aControl);
                    }
                }
            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName.CompareTo("UpdateAllPins") == 0) {
                    this.customPins = ((CustomMap)this.Element).CustomPins;
                    updateAllPins();
                } else if (e.PropertyName.CompareTo("ClearAllPins") == 0) {
                    this.customPins.Clear();
                }
            }
        }
    }
```

### Add Xamarin.Forms.Maps.WPF

To enable the Maps capability with Xamarin.Forms.Platform.WPF you must also add
the Xamarin.Forms.Maps.WPF by John Russell

![Add the Xamarin.Forms.Maps.WPF NuGet](../images/AddXamarinMapsWPF.jpg)

## Build

Right click on the SampleMapsApp.WPF project and select build.

## Run

At the top of the Visual Studio screen, select "Start >"

## Build for Windows 7

Set the project build type to: Release

You can use what ever platform you want here, I have tried them all on Windows 7 and they work just fine: x86, x64 or AnyCpu

Note however that x64 will not work on a Windows 7 machine that is x86!

Right click on the SampleMapsApp.WPF project and select build.

## Generate an installer for Windows 7 or Windows 10

Using Inno Script Studio:

![About Inno Script Studio](images/AboutInno.jpg)

Inno Script Studio Installer can be found at: [Inno Script Studio](https://www.kymoto.org/products/inno-script-studio)

Open the Script file [SampleMapsApp.WPF.iss](../SampleMapsApp/Inno/SampleMapsApp.WPF.iss) using Inno Script Studio

Then in Inno Script Studio select the Compile button.

Copy the output file generated by Inno Script Studio which should be called: 

    C:\SharedProjects\vs2017\XamarinWPFSamples\SampleMapsApp\Installer\WPFv010000\SampleMapsAppWPF010000Setup.exe

to your Windows 7 machine, and run that file.  Make sure your virus protector is temporarily shut off.  Windows 7 Virus Protectors like Avast do not like Inno Compiled Files.  WebRoot does not need to be temporarily shut off.

## Authors

John Russell - Senior Software Engineer II - Indigo Olive Software, Inc.

## License

These samples and all attached documents are free to use, copy, and sell.
