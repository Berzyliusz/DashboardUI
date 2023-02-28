using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace CarSystems.View
{
    public class SpeedMeter
    {
        readonly TextMeshProUGUI speedText;
        readonly Slider speedSlider;
        readonly int vMax;

        float currentSpeed;

        string[] speedStrings;

        public SpeedMeter(TextMeshProUGUI speedText, Slider speedSlider, int vMax)
        {
            this.speedText = speedText;
            this.speedSlider = speedSlider;
            this.vMax = vMax;
            speedText.text = currentSpeed.ToString();

            speedStrings = new string[vMax];
            for (int i = 0; i < vMax; i++)
            {
                speedStrings[i] = i.ToString();
            }
        }

        public void SetSpeed(float targetSpeed)
        {
            DOTween.To(() => currentSpeed, x => currentSpeed = x, targetSpeed, 1.5f)
                .OnUpdate(() => UpdateDisplay());
        }

        void UpdateDisplay()
        {
            speedText.text = speedStrings[((int)currentSpeed)];
            speedSlider.value = currentSpeed / vMax;
        }
    }
}