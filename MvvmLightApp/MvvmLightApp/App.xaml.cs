using System;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using MvvmLightApp.ViewModel;

namespace MvvmLightApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region <-PrivateVars->
        #endregion

        #region <-Constructor->
        static App()
        {
            try
            {
                DispatcherHelper.Initialize();
                ViewModelLocator.Init();
            }
            catch (Exception)
            {   
                throw; //#TODO:log exception
            }
        }

        public App()
        {
            InitializeComponent();
        }
        
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppInit();
        }

        private void AppInit()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DispatcherUnhandledException += LibraryApplication_DispatcherUnhandledException;

            LoadWindow();
        }

        private static void LoadWindow()
        {
            var shellWindow = ServiceLocator.Current.GetInstance<MainWindow>();
            shellWindow.Topmost = true;
            shellWindow.Show();
            shellWindow.Topmost = false;
        }

        #region <-PrivateMethods->
        #endregion

        #region <-ApplicaitonEventHandling->
        void LibraryApplication_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
