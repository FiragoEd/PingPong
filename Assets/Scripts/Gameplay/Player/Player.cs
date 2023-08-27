using System.Reflection.Emit;
using Gameplay.Input;
using Gameplay.Player.MoveController;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private PlayerMoveController _playerMoveController;


        public PlayerMoveController PlayerMoveController => _playerMoveController;
        
        public void Construct(IInputSystem inputSystem)
        {
        }
    }
}