using UnityEngine;

namespace Code.TractorSimulatorInput
{
    [CreateAssetMenu(menuName = "Configs/PlayerID", fileName = "New Player ID")]
    public class RewiredPlayerIDProviderConfig : Config
    {
        [field: SerializeField] public int PlayerID { get; private set; }
    }
}