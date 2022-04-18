using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Core.Input;
using Trell.Movement;
using Trell.Utils;
using UnityEngine;

namespace Trell.Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private MovementAnimator _movementAnimator;

        [SerializeField] private PlayerClickHandler _playerClickListener;

        [SerializeField] private CheckingForRange _checkingForRange;

        private bool _hasTarget => _playerClickListener.HittedEnemy != null;

        private Health _enemy => _playerClickListener.HittedEnemy;

        private bool _inRange => _checkingForRange.InRange(_playerClickListener.HittedEnemy.transform.position);

        private bool _isMouseDown => InputHandler.Instace.IsMouseDown;

        private void Update()
        {
            UpdateAnimatorSpeedParameter();
        }

        private void UpdateAnimatorSpeedParameter()
        {
            _movementAnimator.SetSpeed(_mover.GetSpeed());
        }

        private void FixedUpdate()
        {
            if (_hasTarget && _enemy.IsDied == false)
            {
                if (_inRange == false)
                {
                    _mover.SetTarget(_enemy.transform.position);
                }
                else
                {
                    _mover.Stop();
                }
            }

            else if (_isMouseDown)
            {
                _mover.SetTarget(_playerClickListener.LastClickedPosition);
            }
        }

    }
}