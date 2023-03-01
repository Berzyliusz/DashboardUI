using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarSystems.View
{
    public class SpeedMeter
    {
        readonly TextMeshProUGUI speedText;
        readonly Image speedFillImage;
        readonly int vMax;

        readonly Vector2 fillMinMaxAmounts = new Vector2(0.125f, 0.47f);

        float currentSpeed;

        string[] speedStrings;

        public SpeedMeter(TextMeshProUGUI speedText, Image speedFillImage, int vMax)
        {
            this.speedText = speedText;
            this.speedFillImage = speedFillImage;
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
            var normalizedSpeed = currentSpeed / vMax;
            speedFillImage.fillAmount = Mathf.Lerp(fillMinMaxAmounts.x, fillMinMaxAmounts.y, normalizedSpeed);
        }
    }
}