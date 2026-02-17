using System.Linq;
using System.Text;
using Rewired;
using UnityEngine;

public class TestInputReader : MonoBehaviour
{
    [SerializeField] private int _playerId = 0;
    
    private Player _player;

    private float _cooldownTime = 5f;
    private float _currentTime = 0f;
    
    private void Start()
    {
        _player = ReInput.players.GetPlayer(_playerId);
    }

    private void Update()
    {
        if (_currentTime <= 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player inputs");
            sb.Append($"Player ID {_playerId}");
            sb.Append($" Horizontal {_player.GetAxis("Horizontal")}");
            sb.Append($" Vertical {_player.GetAxis("Vertical")}");
            Debug.Log(sb.ToString());

            foreach (var controller in _player.controllers.Controllers)
            {
                Debug.Log(controller.name + " is " + controller.enabled);
            }
            
            _currentTime = _cooldownTime;
        }
        _currentTime -= Time.deltaTime;
    }
}
