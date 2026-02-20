using System;
using System.Collections.Generic;
using Code.TractorInput.Transmissions;
using UnityEngine;

namespace Code.TractorInput.UI
{
    public class UITractorMainGearboxView : MonoBehaviour
    {
        [SerializeField] private Transform _lever;
        [SerializeField] private Transform _neutralPoint;
        [SerializeField] private Transform _firstGearPoint;
        [SerializeField] private Transform _secondGearPoint;
        [SerializeField] private Transform _thirdGearPoint;
        [SerializeField] private Transform _fourthGearPoint;
        
        private Dictionary<MainGearboxTransmissions, Transform> _transmissionPoints;

        private void Awake()
        {
            _transmissionPoints = new Dictionary<MainGearboxTransmissions, Transform>()
            {
                { MainGearboxTransmissions.Neutral, _neutralPoint},
                { MainGearboxTransmissions.First, _firstGearPoint},
                { MainGearboxTransmissions.Second, _secondGearPoint},
                { MainGearboxTransmissions.Third, _thirdGearPoint},
                { MainGearboxTransmissions.Fourth, _fourthGearPoint}
            };
        }

        public void UpdateMainGearboxTransmissions(MainGearboxTransmissions transmission)
        {
            _lever.position = _transmissionPoints[transmission].position;
        }
    }
}