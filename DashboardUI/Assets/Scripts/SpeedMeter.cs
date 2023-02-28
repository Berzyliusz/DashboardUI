using DG.Tweening;
using TMPro;

namespace CarSystems.View
{
    public class SpeedMeter
    {
        readonly TextMeshProUGUI speedText;

        float currentSpeed;

        string[] speedStrings;

        public SpeedMeter(TextMeshProUGUI speedText, int vMax)
        {
            this.speedText = speedText;
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
                .OnUpdate(() => speedText.text = speedStrings[((int)currentSpeed)]);
        }
    }
}