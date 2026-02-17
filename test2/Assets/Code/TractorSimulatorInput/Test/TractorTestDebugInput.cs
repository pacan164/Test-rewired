using System;
using Code.TractorSimulatorInput;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TractorTestDebugInput : MonoBehaviour
{
    [SerializeField] private TractorInputBehaviour _tractorInputBehaviour;
    [SerializeField] private bool _isDebuging = true;


    private void Awake()
    {
        _tractorInputBehaviour.OnWheelAxisValueChanged += LogWheel;
    }

    private void OnDestroy()
    {
        _tractorInputBehaviour.OnWheelAxisValueChanged -= LogWheel;
    }

    public void LogWheel(float value)
    {
        Debug.Log($"Current wheel axis is {value}");
    }

    private void Update()
    {
        if (!_isDebuging) return;

        Debug.Log($"Current wheel axis via default is {Input.GetAxis("Vertical")} or {Input.GetAxis("Horizontal")}");
    }
}