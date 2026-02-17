using System;
using Rewired;
using UniRx;
using UnityEngine;

namespace Code.TractorSimulatorInput
{
    [Serializable]
    public class TractorInputManager : IDisposable
    {
        [SerializeField] private RewiredPlayerIDProviderConfig _playerIDProviderConfig;
        
        [Header("Wheel")]
        [SerializeField] private RewiredActionInfoConfig _wheelAxisActionInfoConfig;
        
        [Header("MainGearbox")]
        [SerializeField] private RewiredActionInfoConfig _mainNeutralGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainFirstGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainSecondGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainThirdGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _mainFourthGearActionInfo;
        
        [Header("GearboxDivider")]
        [SerializeField] private RewiredActionInfoConfig _dividerPressedConfig;
        [SerializeField] private RewiredActionInfoConfig _dividerNeutralGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _dividerFirstGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _dividerSecondGearActionInfo;
        [SerializeField] private RewiredActionInfoConfig _dividerThirdGearActionInfo;
        
        private Player _player;

        public FloatReactiveProperty WheelAxis { get; private set; } = new();
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
            MainNeutralGear.Value = _player.GetButtonDown(_mainNeutralGearActionInfo.ActionName);
            MainFirstGear.Value = _player.GetButtonDown(_mainFirstGearActionInfo.ActionName);
            MainSecondGear.Value = _player.GetButtonDown(_mainSecondGearActionInfo.ActionName);
            MainThirdGear.Value = _player.GetButtonDown(_mainThirdGearActionInfo.ActionName);
            MainFourthGear.Value = _player.GetButtonDown(_mainFourthGearActionInfo.ActionName);
            DividerPressed.Value = _player.GetButtonDown(_dividerPressedConfig.ActionName);
            DividerNeutralGear.Value = _player.GetButtonDown(_dividerNeutralGearActionInfo.ActionName);
            DividerFirstGear.Value = _player.GetButtonDown(_dividerFirstGearActionInfo.ActionName);
            DividerSecondGear.Value = _player.GetButtonDown(_dividerSecondGearActionInfo.ActionName);
            DividerThirdGear.Value = _player.GetButtonDown(_dividerThirdGearActionInfo.ActionName);
        }

        public void Dispose()
        {
            WheelAxis?.Dispose();
            MainNeutralGear?.Dispose();
            MainFirstGear?.Dispose();
            MainSecondGear?.Dispose();
            MainThirdGear?.Dispose();
            MainFourthGear?.Dispose();
            DividerPressed?.Dispose();
            DividerNeutralGear?.Dispose();
            DividerFirstGear?.Dispose();
            DividerSecondGear?.Dispose();
            DividerThirdGear?.Dispose();
        }
    }
}