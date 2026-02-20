using Code.Configs;
using UnityEngine;

namespace Code.TractorInput
{
    [CreateAssetMenu(menuName = "Configs/PlayerID", fileName = "New Player ID")]
    public class RewiredPlayerIDProviderConfig : Config
    {
        [field: SerializeField] public int PlayerID { get; private set; }
    }
}