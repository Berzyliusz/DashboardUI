using CarSystems.View;
using System;

namespace CarSystems
{

    /// <summary>
    /// Mock, just to display demo functions.
    /// </summary>
    public class DemoInputs
    {
        IDashboard dashboard;
        Random random;

        float inputChangeTime;
        float timer;

        public DemoInputs(IDashboard dashboard, float inputChangeTime)
        {
            this.inputChangeTime = inputChangeTime;
            timer = inputChangeTime;
            this.dashboard = dashboard;
            random= new Random();
            DisplayRandomInputs();
        }

        public void Update(float deltaTime)
        {
            timer -= deltaTime;

            if (timer < 0)
            {
                timer = inputChangeTime;
                DisplayRandomInputs();
            }
        }

        void DisplayRandomInputs()
        {
            dashboard.SetSpeed(random.Next(240));
            dashboard.SetDriveMode((DriveMode)random.Next(Enum.GetNames(typeof(DriveMode)).Length));
            var isEVOn = random.Next(2);
            var isSportOn = random.Next(2);
            dashboard.SetEVMode(isEVOn == 0);
            dashboard.SetSportMode(isSportOn == 0);
        }
    }
} 