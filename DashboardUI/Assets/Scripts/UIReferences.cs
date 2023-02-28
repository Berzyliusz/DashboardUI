using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CarSystems.Dashboard
{
    [System.Serializable]
    public struct MusicPlayerReferences
    {
        [field: SerializeField] public TextMeshProUGUI SongName { get; private set; }
        [field: SerializeField] public TextMeshProUGUI AuthorName { get; private set; }
        [field: SerializeField] public Slider PlaybackSlider { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PlaybackTimer { get; private set; }
    }

    public class UIReferences : MonoBehaviour
    {
        [field:SerializeField] public MusicPlayerReferences MusicPlayerReferences { get; private set; }
    }
}