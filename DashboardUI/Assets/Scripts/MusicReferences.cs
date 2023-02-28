using UnityEngine;

namespace CarSystems
{
    /// <summary>
    /// Mock class. 
    /// Assume music is downloaded / loaded externally / played from phone etc.
    /// </summary>
    public class MusicReferences : MonoBehaviour
    {
        [field: SerializeField] public GameObject[] musicReferences { get; private set; }
    }
}