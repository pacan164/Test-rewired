using Code.ServiceLocatorPattern;
using Code.TractorInput.Systems;
using UnityEngine;

namespace Code.Installers
{
    public class TractorInputInstaller : MonoBehaviour
    {
        [SerializeField] private TractorInputBehaviour _tractorInputBehaviour;
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(_tractorInputBehaviour);
            ServiceLocator.Instance.Register(new TractorInputPresenter(_tractorInputBehaviour));
        }
    }
}