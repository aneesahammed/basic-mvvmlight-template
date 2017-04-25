/*
 * @file:SingleInstanceManager
 * @brief: for single instance of application.
 * @author:AA
 * @Credits:http://www.switchonthecode.com/tutorials/wpf-writing-a-single-instance-application                
 */

using System;
using Microsoft.VisualBasic.ApplicationServices;

namespace MvvmLightApp
{
    public sealed class SingleInstanceManager:WindowsFormsApplicationBase
    {
        #region <-Properties->
        public App App { get; private set; }
        #endregion

        #region <-Constructor->
        private SingleInstanceManager()
        {
            IsSingleInstance = true;
        }
        #endregion


        #region <-Main->

        /// <summary>
        /// Main method which creates a new SingleInstanceManager and passes in arguments.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            new SingleInstanceManager().Run(args);
        }
        #endregion
        

        #region <-ProtectedMethods->

        /// <summary>
        /// Overrides the OnStartup Method from Base.
        /// On first startup, creates a new Application and runs it. 
        /// </summary>
        /// <returns>A System.Boolean that indicates if the application should continue starting up.</returns>
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            App = new App();
            App.Run();

            return false;
        }

        /// <summary>
        /// Overrides the OnStartupNextInstance Method from Base.
        /// On subsequent startup, restore the current application instance and passes any command line arguments to it
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
                base.OnStartupNextInstance(eventArgs);
                App.MainWindow.Activate();
        }
        #endregion
    }
}
