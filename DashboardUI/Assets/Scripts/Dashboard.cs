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

        public Dashboard(UIReferences references)
        {
            driveMode = new DriveModeHandler(references.CentralElementReferences.DriveModes);
        }

        public void SetDriveMode(DriveMode mode)
        {
            driveMode.SetDriveMode(mode);
        }

        public void SetSpeed(float speed)
        {
            // pass to speedmeter
            // speeedmeter handles:
            // 1. slider of speed
            // 2. speed value 
        }
    }
}