using Rewired;
using UnityEngine;

namespace Code
{
    public class TestInputEvents : MonoBehaviour
    {
        private void Awake() 
        {
            ReInput.ControllerConnectedEvent += OnControllerConnected;
            ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
            ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;
        }

        private void OnControllerConnected(ControllerStatusChangedEventArgs args) 
        {
            Debug.Log("A controller was connected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
        }

        private void OnControllerDisconnected(ControllerStatusChangedEventArgs args) 
        {
            Debug.Log("A controller was disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
        }

        private void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args) 
        {
            Debug.Log("A controller is being disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
        }

        private void OnDestroy() 
        {
            ReInput.ControllerConnectedEvent -= OnControllerConnected;
            ReInput.ControllerDisconnectedEvent -= OnControllerDisconnected;
            ReInput.ControllerPreDisconnectEvent -= OnControllerPreDisconnect;
        }
    }
}