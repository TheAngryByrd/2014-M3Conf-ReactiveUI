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
using ReactiveUI;

namespace M3Conf_ReactiveUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IViewFor<ReactiveMainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           // DataContext = new ClassicMainWindowViewModel();
            ViewModel = new ReactiveMainWindowViewModel();
            this.Bind(ViewModel, vm => vm.FirstName, v => v.FirstName.Text);
            this.Bind(ViewModel, vm => vm.LastName, v => v.LastName.Text);
            this.Bind(ViewModel, vm => vm.FavoriteColor, v => v.FavoriteColor.Text);
            this.OneWayBind(ViewModel, vm => vm.FullName, v => v.FullName.Text);
            this.OneWayBind(ViewModel, vm => vm.Sentence, v => v.Sentence.Text);
            this.BindCommand(ViewModel, vm => vm.DoWorkCommand,v => v.DoWork);
        }
        //WPF Boilerplate
        public ReactiveMainWindowViewModel ViewModel
        {
            get { return (ReactiveMainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ReactiveMainWindowViewModel), typeof(MainWindow), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ReactiveMainWindowViewModel)value; }
        }
    }
}
