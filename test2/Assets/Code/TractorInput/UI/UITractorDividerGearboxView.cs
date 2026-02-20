using System.Collections.Generic;
using Code.TractorInput.Transmissions;
using UnityEngine;

namespace Code.TractorInput.UI
{
    public class UITractorDividerGearboxView : MonoBehaviour
    {
        [SerializeField] private Transform _lever;
        [SerializeField] private GameObject _leverPressedIcon;
        [SerializeField] private Transform _neutralPoint;
        [SerializeField] private Transform _firstGearPoint;
        [SerializeField] private Transform _secondGearPoint;
        [SerializeField] private Transform _thirdGearPoint;
        
        private Dictionary<DividerTransmissions, Transform> _transmissionPoints;

        private void Awake()
        {
            _transmissionPoints = new Dictionary<DividerTransmissions, Transform>()
            {
                { DividerTransmissions.Neutral, _neutralPoint},
                { DividerTransmissions.First, _firstGearPoint},
                { DividerTransmissions.Second, _secondGearPoint},
                { DividerTransmissions.Third, _thirdGearPoint}
            };
        }

        public void UpdateDividerTransmissions(DividerTransmissions transmission)
        {
            _lever.position = _transmissionPoints[transmission].position;
        }

        public void UpdateLeverPress(bool pressed)
        {
            _leverPressedIcon.SetActive(pressed);
        }
    }
}