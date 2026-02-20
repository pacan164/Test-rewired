using System;
using Code.ServiceLocatorPattern;
using Code.TractorInput.Systems;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.TractorInput.UI
{
    public class UITractorInputView : MonoBehaviour, IDisposable
    {
        [SerializeField] private UITractorWheelView _wheelView;
        [SerializeField] private UITractorPedalsView _pedalsView;
        [SerializeField] private UITractorMainGearboxView _mainGearboxView;
        [SerializeField] private UITractorDividerGearboxView _dividerGearboxView;
        
        private readonly TractorInputPresenter _presenter = ServiceLocator.Instance.Resolve<TractorInputPresenter>();
        
        private CompositeDisposable _disposables = new ();
        
        private void Start()
        {
            _presenter.WheelAxisValue
                .Subscribe(_wheelView.UpdateWheel)
                .AddTo(_disposables);
            
            _presenter.AccelerationValue
                .Subscribe(_pedalsView.UpdateAcceleration)
                .AddTo(_disposables);
            
            _presenter.BrakeValue
                .Subscribe(_pedalsView.UpdateBrake)
                .AddTo(_disposables);
            
            _presenter.SteeringValue
                .Subscribe(_pedalsView.UpdateSteering)
                .AddTo(_disposables);

            _presenter.MainGearboxTransmissionState
                .Subscribe(_mainGearboxView.UpdateMainGearboxTransmissions)
                .AddTo(_disposables);
            
            _presenter.DividerTransmissionState
                .Subscribe(_dividerGearboxView.UpdateDividerTransmissions)
                .AddTo(_disposables);
            
            _presenter.IsDividerPressed
                .Subscribe(_dividerGearboxView.UpdateLeverPress)
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}