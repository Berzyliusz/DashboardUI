using CarSystems.View;
using UnityEngine;

namespace CarSystems
{
    public class Systems : MonoBehaviour
    {
        [SerializeField] UIReferences references;

        IDashboard dashboard;

        private void Awake()
        {
            dashboard = new Dashboard(references);
            DemoInputs inputs = new DemoInputs(dashboard);
        }
        // Expose an interface allowing to update the dashboard

        // Setup and collect all dashboard elements in a facade
    }
}