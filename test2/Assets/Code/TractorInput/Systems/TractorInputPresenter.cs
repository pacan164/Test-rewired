using System;
using Code.TractorInput.Transmissions;
using UniRx;

namespace Code.TractorInput.Systems
{
    public class TractorInputPresenter : IDisposable
    {
        private readonly TractorInputBehaviour _tractorInputBehaviour;
        private readonly CompositeDisposable _disposables = new ();
        
        public IObservable<float> WheelAxisValue => _tractorInputBehaviour.WheelAxisValue;
        public IObservable<float> AccelerationValue => _tractorInputBehaviour.AccelerationValue;
        public IObservable<float> BrakeValue => _tractorInputBehaviour.BrakeValue;
        public IObservable<float> SteeringValue => _tractorInputBehaviour.SteeringValue;
        public IObservable<MainGearboxTransmissions> MainGearboxTransmissionState => _tractorInputBehaviour.MainGearboxTransmissionState;
        public IObservable<DividerTransmissions> DividerTransmissionState => _tractorInputBehaviour.DividerTransmissionState;
        public IObservable<bool> IsDividerPressed => _tractorInputBehaviour.IsDividerPressed;

        public TractorInputPresenter(TractorInputBehaviour tractorInputBehaviour)
        {
            _tractorInputBehaviour = tractorInputBehaviour;
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}