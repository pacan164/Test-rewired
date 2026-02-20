using System;
using Rewired;
using UniRx;
using UnityEngine;

namespace Code.TractorInput.Systems
{
    [Serializable]
    public class TractorInputManager
    {
        [SerializeField] private RewiredPlayerIDProviderConfig _playerIDProviderConfig;
        
        [Header("Wheel")]
        [SerializeField] private RewiredActionInfoConfig _wheelAxisActionInfoConfig;
        
        [Header("Pedals")]
        [SerializeField] private RewiredActionInfoConfig _accelerationActionInfoConfig;
        [SerializeField] private RewiredActionInfoConfig _brakeActionInfoConfig;
        [SerializeField] private RewiredActionInfoConfig _steeringActionInfoConfig;
        
        [Header("MainGearbox")]
        [SerializeField] private RewiredActionInfoConfig _mainFirstGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainSecondGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainThirdGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainFourthGearActionInfo;
        
        [Header("GearboxDivider")]
        [SerializeField] private RewiredActionInfoConfig _dividerPressedConfig;
        [SerializeField] private RewiredActionInfoConfig _dividerFirstGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _dividerSecondGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _dividerThirdGearActionInfo;
        
        private Player _player;

        public FloatReactiveProperty WheelAxis { get; private set; } = new();
        public FloatReactiveProperty Acceleration { get; private set; } = new();
        public FloatReactiveProperty Brake { get; private set; } = new();
        public FloatReactiveProperty Steering { get; private set; } = new();
        public BoolReactiveProperty MainNeutralGear { get; private set; } = new();
        public BoolReactiveProperty MainFirstGear { get; private set; } = new();
        public BoolReactiveProperty MainSecondGear { get; private set; } = new();
        public BoolReactiveProperty MainThirdGear { get; private set; } = new();
        public BoolReactiveProperty MainFourthGear { get; private set; } = new();
        public BoolReactiveProperty DividerPressed { get; private set; } = new();
        public BoolReactiveProperty DividerNeutralGear { get; private set; } = new();
        public BoolReactiveProperty DividerFirstGear { get; private set; } = new();
        public BoolReactiveProperty DividerSecondGear { get; private set; } = new();
        public BoolReactiveProperty DividerThirdGear { get; private set; } = new();

        public void Initialize()
        {
            _player = ReInput.players.GetPlayer(_playerIDProviderConfig.PlayerID);
        }

        public void Tick()
        {
            WheelAxis.Value = _player.GetAxis(_wheelAxisActionInfoConfig.ActionName);
            
            Acceleration.Value = _player.GetAxis(_accelerationActionInfoConfig.ActionName);
            Brake.Value = _player.GetAxis(_brakeActionInfoConfig.ActionName);   
            Steering.Value = _player.GetAxis(_steeringActionInfoConfig.ActionName);
            
            MainFirstGear.Value = _player.GetButtonDown(_mainFirstGearActionInfo.ActionName);
            MainSecondGear.Value = _player.GetButtonDown(_mainSecondGearActionInfo.ActionName);
            MainThirdGear.Value = _player.GetButtonDown(_mainThirdGearActionInfo.ActionName);
            MainFourthGear.Value = _player.GetButtonDown(_mainFourthGearActionInfo.ActionName);
            MainNeutralGear.Value = !(MainFirstGear.Value || MainSecondGear.Value || MainThirdGear.Value || MainFourthGear.Value);
            
            DividerPressed.Value = _player.GetButtonDown(_dividerPressedConfig.ActionName);
            DividerFirstGear.Value = _player.GetButtonDown(_dividerFirstGearActionInfo.ActionName);
            DividerSecondGear.Value = _player.GetButtonDown(_dividerSecondGearActionInfo.ActionName);
            DividerThirdGear.Value = _player.GetButtonDown(_dividerThirdGearActionInfo.ActionName);
            DividerNeutralGear.Value = !(DividerFirstGear.Value || DividerSecondGear.Value || DividerThirdGear.Value);
        }
    }
}