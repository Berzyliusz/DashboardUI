using DG.Tweening;
using System;
using System.Collections.Generic;

namespace CarSystems.View
{
    public class IndicatorHandler
    {
        Dictionary<IndicatorType, IndicatorReference> indicators;

        public IndicatorHandler(IndicatorReference[] indicatorReferences)
        {
            indicators = new Dictionary<IndicatorType, IndicatorReference>();

            foreach(var indicatorReference in indicatorReferences)
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

        }
    }
}