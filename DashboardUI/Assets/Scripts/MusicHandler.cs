using System;
using TMPro;
using UnityEngine.UI;

namespace CarSystems.View
{
    public class MusicHandler
    {
        readonly Slider playbackSlider;
        readonly TextMeshProUGUI playbackTimer;

        float playbackTime;
        float mockEverySongLength = 59f;

        public MusicHandler(MusicPlayerReferences references)
        {
            playbackSlider = references.PlaybackSlider;
            playbackTimer = references.PlaybackTimer;

            // Assume we would also get songs data, album covers etc. injected here
        }

        public void Next()
        {
            ResetTimerAndSlider();
        }

        public void Previous()
        {
            ResetTimerAndSlider();
        }

        public void Update(float deltaTime)
        {
            playbackTime += deltaTime;
            

            if(playbackTime > mockEverySongLength)
            {
                ResetTimerAndSlider();
                return;
            }

            playbackTimer.text = playbackTime.ToString("0.00");
            playbackSlider.value = playbackTime / mockEverySongLength;
        }

        private void ResetTimerAndSlider()
        {
            playbackSlider.value = 0;
            playbackTimer.text = "0:00";
        }
    }
}