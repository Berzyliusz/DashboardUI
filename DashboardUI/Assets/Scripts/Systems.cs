using CarSystems.View;
using System.Collections;
using UnityEngine;

namespace CarSystems
{
    public struct CarParams
    {
        public int Vmax => 240;
    }

    public class Systems : MonoBehaviour
    {
        [SerializeField] MusicReferences musicReferences;
        [SerializeField] UIReferences references;

        CarParams carParams;
        IDashboard dashboard;
        DemoInputs inputs;

        void Awake()
        {
            Screen.SetResolution(1920, 720, true, 60);
            this.enabled = false;

            StartCoroutine(StartupSystems());
        }

        IEnumerator StartupSystems()
        {
            yield return new WaitForSeconds(0.1f);

            dashboard = new Dashboard(references, carParams, musicReferences);
            inputs = new DemoInputs(dashboard, 2f);
            this.enabled = true;
        }

        void Update()
        {
            dashboard.Update(Time.deltaTime);
            inputs.Update(Time.deltaTime);
        }
    }
}