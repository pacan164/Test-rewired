using Code.Configs;
using UnityEngine;

namespace Code.TractorInput
{
    [CreateAssetMenu(menuName = "Configs/ActionInfo", fileName = "New Action Info")]
    public class RewiredActionInfoConfig : Config
    {
        [field: SerializeField] public string ActionName { get; private set; }
    }
}