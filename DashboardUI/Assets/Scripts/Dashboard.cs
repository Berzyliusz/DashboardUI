using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarSystems.View
{
    public interface IDashboard
    {
        void SetDriveMode(DriveMode mode);
        void SetSpeed(float speed);
    }

    public class Dashboard : IDashboard
    {
        DriveModeHandler driveMode;
        SpeedMeter speedMeter;

        public Dashboard(UIReferences references, CarParams carParams)
        {
            driveMode = new DriveModeHandler(references.CentralElementReferences.DriveModes);
            speedMeter = new SpeedMeter(references.CentralElementReferences.SpeedText, carParams.Vmax);
        }

        public void SetDriveMode(DriveMode mode)
        {
            driveMode.SetDriveMode(mode);
        }

        public void SetSpeed(float speed)
        {
            speedMeter.SetSpeed(speed);
        }
    }
}