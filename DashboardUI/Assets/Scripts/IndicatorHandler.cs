using System;
using System.Collections.Generic;

namespace CarSystems.View
{
    public class IndicatorHandler
    {
        Dictionary<IndicatorType, IndicatorReference> indicators;
        HashSet<IndicatorReference> blinkingIndicators;

        readonly float blinkingTime = 0.4f;
        float timer;

        public IndicatorHandler(IndicatorReference[] indicatorReferences)
        {
            indicators = new Dictionary<IndicatorType, IndicatorReference>();
            blinkingIndicators = new HashSet<IndicatorReference>();
            timer = blinkingTime;

            foreach (var indicatorReference in indicatorReferences)
            {
                indicators[indicatorReference.Type] = indicatorReference;
                SetIndicator(indicatorReference.Type, false);
            }
        }

        public void SetIndicator(IndicatorType type, bool isOn)
        {
            if(!indicators.ContainsKey(type))
            {
                throw new ArgumentException($"{type} not handled in indicator handler!");
            }

            var indicator = indicators[type];
            var imageToUse = isOn ? indicator.OnSprite : indicator.OffSprite;
            indicator.ReferenceImage.sprite = imageToUse;
        }

        public void SetIndicatorBlinking(IndicatorType type, bool isOn)
        {
            if (!indicators.ContainsKey(type))
            {
                throw new ArgumentException($"{type} not handled in indicator handler!");
            }

            if (isOn)
            {
                blinkingIndicators.Add(indicators[type]);
            }
            else
            {
                blinkingIndicators.Remove(indicators[type]);
                indicators[type].ReferenceImage.sprite = indicators[type].OffSprite;
            }
        }

        public void Update(float deltaTime)
        {
            timer -= deltaTime;

            if(timer < 0)
            {
                timer = blinkingTime;

                foreach(var blinkingIndicator in blinkingIndicators)
                {
                    if (blinkingIndicator.ReferenceImage.sprite == blinkingIndicator.OnSprite)
                        blinkingIndicator.ReferenceImage.sprite = blinkingIndicator.OffSprite;
                    else
                        blinkingIndicator.ReferenceImage.sprite = blinkingIndicator.OnSprite;
                }
            }
        }
    }
}