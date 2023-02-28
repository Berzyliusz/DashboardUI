using TMPro;
using UnityEngine.UI;

namespace CarSystems.View
{
    public class MusicHandler
    {
        readonly Slider playbackSlider;
        readonly TextMeshProUGUI playbackTimer;

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

        private void ResetTimerAndSlider()
        {
            playbackSlider.value = 0;
            playbackTimer.text = "0:00";
        }
    }
}