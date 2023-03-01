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
            dashboard.SetEVMode(random.Next(2) == 0);
            dashboard.SetSportMode(random.Next(2) == 0);

            var nextOrPreviousSong = random.Next(2);
            if (nextOrPreviousSong == 0)
                dashboard.NextSong();
            if (nextOrPreviousSong == 1)
                dashboard.PreviousSong();

            dashboard.SetIndicatorBlinking(IndicatorType.LeftTurn, random.Next(2) == 0);
            dashboard.SetIndicatorBlinking(IndicatorType.RightTurn, random.Next(2) == 0);

            for (int i = 0; i < 6; i++)
            {
                var indicatorToModify = random.Next(Enum.GetNames(typeof(IndicatorType)).Length - 2);
                dashboard.SetIndicator((IndicatorType)indicatorToModify, random.Next(2) == 0);
            }
        }
    }
} 