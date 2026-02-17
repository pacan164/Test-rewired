using UnityEngine;

namespace Code.TractorSimulatorInput
{
    [CreateAssetMenu(menuName = "Configs/ActionInfo", fileName = "New Action Info")]
    public class RewiredActionInfoConfig : Config
    {
        [field: SerializeField] public string ActionName { get; private set; }
    }
}