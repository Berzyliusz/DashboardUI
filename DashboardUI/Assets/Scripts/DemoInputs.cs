using CarSystems.View;
using DG.Tweening;

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
            
        }
    }
}