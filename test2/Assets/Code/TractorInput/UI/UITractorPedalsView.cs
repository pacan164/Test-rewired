using UnityEngine;
using UnityEngine.UI;

namespace Code.TractorInput.UI
{
    public class UITractorPedalsView : MonoBehaviour
    {
        [SerializeField] private Slider _accelerationSlider;
        [SerializeField] private Slider _brakeSlider;
        [SerializeField] private Slider _steeringSlider;

        public void UpdateAcceleration(float acceleration)
        {
            _accelerationSlider.value = acceleration;
        }

        public void UpdateBrake(float brake)
        {
            _brakeSlider.value = brake;
        }

        public void UpdateSteering(float steering)
        {
            _steeringSlider.value = steering;
        }
    }
}