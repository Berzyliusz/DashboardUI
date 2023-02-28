using CarSystems.View;
using DG.Tweening;
using System;

namespace CarSystems
{

    /// <summary>
    /// Mock, just to display demo functions.
    /// </summary>
    public class DemoInputs
    {
        IDashboard dashboard;

        public DemoInputs(IDashboard dashboard)
        {
            this.dashboard = dashboard;

            StartDemoInputs();
        }

        void StartDemoInputs()
        {
            SwitchDriveModes();
        }

        private void SwitchDriveModes()
        {
            // keep increasing the index of enum and switching over time
            dashboard.SetDriveMode(DriveMode.Reverse);
        }
    }
}