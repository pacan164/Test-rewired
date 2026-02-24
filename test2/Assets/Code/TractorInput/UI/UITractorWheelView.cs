using UnityEngine;

namespace Code.TractorInput.UI
{
    public class UITractorWheelView : MonoBehaviour
    {
        [SerializeField] private Transform _wheelImage;
        [SerializeField] private Vector3 _rotationAxis;
        [SerializeField] private bool _isInverted = true;
        [SerializeField] private float _minWheelAngle;
        [SerializeField] private float _maxWheelAngle;

        public void UpdateWheel(float value)
        {
            float rotationAngle = value * (_maxWheelAngle - _minWheelAngle);
            rotationAngle = _isInverted ? -rotationAngle : rotationAngle;
            _wheelImage.localRotation = Quaternion.Euler(_rotationAxis * rotationAngle);
        }
    }
}