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
        public Dashboard(UIReferences references)
        {

        }

        public void SetDriveMode(DriveMode mode)
        {
            
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