using System;
using Code.TractorInput.Transmissions;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace Code.TractorInput.Systems
{
    public class TractorInputBehaviour : MonoBehaviour, IDisposable
    {
        [SerializeField] private TractorInputManager _tractorInputManager;

        private readonly CompositeDisposable _disposable = new();

        public FloatReactiveProperty WheelAxisValue { get; private set; } = new (0f);
        public FloatReactiveProperty AccelerationValue { get; private set; } = new (0f);
        public FloatReactiveProperty BrakeValue { get; private set; } = new (0f);
        public FloatReactiveProperty SteeringValue { get; private set; } = new (0f);

        public ReactiveProperty<MainGearboxTransmissions> MainGearboxTransmissionState { get; private set; } =
            new (MainGearboxTransmissions.Neutral);

        public ReactiveProperty<DividerTransmissions> DividerTransmissionState { get; private set; } =
            new (DividerTransmissions.Neutral);

        public BoolReactiveProperty IsDividerPressed { get; private set; } = new BoolReactiveProperty(false);

        private void Awake()
        {
            _tractorInputManager.Initialize();
            SubscribeWheelInputs();
            SubscribePedalsInputs();
            SubscribeMainGearboxInputs();
            SubscribeDividerInputs();
        }

        private void Update()
        {
            _tractorInputManager.Tick();
        }

        private void SubscribeWheelInputs()
        {
            _tractorInputManager.WheelAxis
                .Subscribe(SetWheelValue)
                .AddTo(_disposable);
        }

        private void SetWheelValue(float value)
        {
            WheelAxisValue.Value = value;
        }

        private void SubscribePedalsInputs()
        {
            _tractorInputManager.Acceleration
                .Subscribe(SetAccelerationValue)
                .AddTo(_disposable);
            _tractorInputManager.Brake
                .Subscribe(SetBrakeValue)
                .AddTo(_disposable);
            _tractorInputManager.Steering
                .Subscribe(SetSteeringValue)
                .AddTo(_disposable);
        }

        private void SetAccelerationValue(float value)
        {
            AccelerationValue.Value = value;
        }

        private void SetBrakeValue(float value)
        {
            BrakeValue.Value = value;
        }

        private void SetSteeringValue(float value)
        {
            SteeringValue.Value = value;
        }

        private void SubscribeMainGearboxInputs()
        {
            _tractorInputManager.MainNeutralGear
                .Subscribe((active) => SetMainGearboxState(active, MainGearboxTransmissions.Neutral))
                .AddTo(_disposable);
            _tractorInputManager.MainFirstGear
                .Subscribe((active) => SetMainGearboxState(active, MainGearboxTransmissions.First))
                .AddTo(_disposable);
            _tractorInputManager.MainSecondGear
                .Subscribe((active) => SetMainGearboxState(active, MainGearboxTransmissions.Second))
                .AddTo(_disposable);
            _tractorInputManager.MainThirdGear
                .Subscribe((active) => SetMainGearboxState(active, MainGearboxTransmissions.Third))
                .AddTo(_disposable);
            _tractorInputManager.MainFourthGear
                .Subscribe((active) => SetMainGearboxState(active, MainGearboxTransmissions.Fourth))
                .AddTo(_disposable);
        }

        private void SetMainGearboxState(bool active, MainGearboxTransmissions state)
        {
            if (active && state != MainGearboxTransmissionState.Value)
            {
                MainGearboxTransmissionState.Value = state;
            }
        }

        private void SubscribeDividerInputs()
        {
            _tractorInputManager.DividerPressed
                .Subscribe(PressDivider)
                .AddTo(_disposable);
            _tractorInputManager.DividerNeutralGear
                .Subscribe((active) => SetDividerState(active, DividerTransmissions.Neutral))
                .AddTo(_disposable);
            _tractorInputManager.DividerFirstGear
                .Subscribe((active) => SetDividerState(active, DividerTransmissions.First))
                .AddTo(_disposable);
            _tractorInputManager.DividerSecondGear
                .Subscribe((active) => SetDividerState(active, DividerTransmissions.Second))
                .AddTo(_disposable);
            _tractorInputManager.DividerThirdGear
                .Subscribe((active) => SetDividerState(active, DividerTransmissions.Third))
                .AddTo(_disposable);
        }

        private void PressDivider(bool isDividerPressed)
        {
            IsDividerPressed.Value = isDividerPressed;
        }

        private void SetDividerState(bool active, DividerTransmissions state)
        {
            if (active && state != DividerTransmissionState.Value)
            {
                DividerTransmissionState.Value = state;
            }
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}