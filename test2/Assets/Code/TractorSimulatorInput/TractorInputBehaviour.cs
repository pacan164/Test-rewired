using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace Code.TractorSimulatorInput
{
    public class TractorInputBehaviour : MonoBehaviour
    {
        [SerializeField] private TractorInputManager _tractorInputManager;
        
        [SerializeField] private UnityEvent<float> _onWheelAxisValueChanged;
        [SerializeField] private UnityEvent<MainGearboxTransmissions> _onMainGearboxStateChanged;
        [SerializeField] private UnityEvent<DividerTransmissions, bool> _onDividerStateChanged;
        
        private float _wheelAxisValue = 0f;
        private MainGearboxTransmissions _mainGearboxTransmission = MainGearboxTransmissions.Neutral;
        private DividerTransmissions _dividerTransmission = DividerTransmissions.Neutral;
        private bool _isDividerPressed = false;
        
        public Action<float> OnWheelAxisValueChanged = delegate { };
        public Action<MainGearboxTransmissions> OnMainGearboxStateChanged = delegate { };
        public Action<DividerTransmissions, bool> OnDividerStateChanged = delegate { };

        private void Awake()
        {
            _tractorInputManager.Initialize();
            
            OnWheelAxisValueChanged += _onWheelAxisValueChanged.Invoke;
            OnMainGearboxStateChanged += _onMainGearboxStateChanged.Invoke;
            OnDividerStateChanged += _onDividerStateChanged.Invoke;

            _tractorInputManager.WheelAxis.Subscribe(SetWheelValue);

            _tractorInputManager.MainNeutralGear.Subscribe((active) =>
                SetMainGearboxState(active, MainGearboxTransmissions.Neutral));
            _tractorInputManager.MainFirstGear.Subscribe((active) =>
                SetMainGearboxState(active, MainGearboxTransmissions.First));
            _tractorInputManager.MainSecondGear.Subscribe((active) =>
                SetMainGearboxState(active, MainGearboxTransmissions.Second));
            _tractorInputManager.MainThirdGear.Subscribe((active) =>
                SetMainGearboxState(active, MainGearboxTransmissions.Third));
            _tractorInputManager.MainFourthGear.Subscribe((active) =>
                SetMainGearboxState(active, MainGearboxTransmissions.Fourth));

            _tractorInputManager.DividerPressed.Subscribe(PressDivider);
            _tractorInputManager.DividerNeutralGear.Subscribe((active) =>
                SetDividerState(active, DividerTransmissions.Neutral));
            _tractorInputManager.DividerFirstGear.Subscribe((active) =>
                SetDividerState(active, DividerTransmissions.First));
            _tractorInputManager.DividerSecondGear.Subscribe((active) =>
                SetDividerState(active, DividerTransmissions.Second));
            _tractorInputManager.DividerThirdGear.Subscribe((active) =>
                SetDividerState(active, DividerTransmissions.Third));
        }

        private void OnDestroy()
        {
            OnWheelAxisValueChanged -= _onWheelAxisValueChanged.Invoke;
            OnMainGearboxStateChanged -= _onMainGearboxStateChanged.Invoke;
            OnDividerStateChanged -= _onDividerStateChanged.Invoke;
        }

        private void Update()
        {
            _tractorInputManager.Tick();
        }

        public void SetMainGearboxState(bool active, MainGearboxTransmissions state)
        {
            if (active && state != _mainGearboxTransmission)
            {
                _mainGearboxTransmission = state;
                OnMainGearboxStateChanged(_mainGearboxTransmission);
            }
        }

        public void PressDivider(bool isDividerPressed)
        {
            _isDividerPressed = isDividerPressed;
        }

        public void SetDividerState(bool active, DividerTransmissions state)
        {
            if (active && state != _dividerTransmission)
            {
                _dividerTransmission = state;
                OnDividerStateChanged(_dividerTransmission, _isDividerPressed);
            }
        }

        public void SetWheelValue(float value)
        {
            _wheelAxisValue = value;
            OnWheelAxisValueChanged(_wheelAxisValue);
        }
    }
}