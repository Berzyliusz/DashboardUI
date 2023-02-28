using CarSystems.View;
using UnityEngine;

namespace CarSystems
{
    public struct CarParams
    {
        public int Vmax => 240;
    }

    public class Systems : MonoBehaviour
    {
        [SerializeField] UIReferences references;

        CarParams carParams;
        IDashboard dashboard;
        DemoInputs inputs;

        void Awake()
        {
            dashboard = new Dashboard(references, carParams);
            inputs = new DemoInputs(dashboard, 2f);
        }

        void Update()
        {
            dashboard.Update(Time.deltaTime);
            inputs.Update(Time.deltaTime);
        }
    }
}