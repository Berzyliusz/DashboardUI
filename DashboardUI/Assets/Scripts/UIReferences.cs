using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CarSystems.View
{
    [System.Serializable]
    public struct MusicPlayerReferences
    {
        [field: SerializeField] public TextMeshProUGUI SongName { get; private set; }
        [field: SerializeField] public TextMeshProUGUI AuthorName { get; private set; }
        [field: SerializeField] public Slider PlaybackSlider { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PlaybackTimer { get; private set; }
    }

    [System.Serializable]
    public struct CentralElementReferences
    {
        [field: SerializeField] public TextMeshProUGUI SpeedText { get; private set; }
        [field: SerializeField] public DriveModeReference[] DriveModes { get; private set; }
    }

    [System.Serializable]
    public struct DriveModeReference
    {
        [field: SerializeField] public TextMeshProUGUI ModeText { get; private set; }
        [field: SerializeField] public DriveMode Mode { get; private set; }
    }


    public class UIReferences : MonoBehaviour
    {
        [field: SerializeField] public MusicPlayerReferences MusicPlayerReferences { get; private set; }
        [field: SerializeField] public CentralElementReferences CentralElementReferences { get; private set; }
    }
}