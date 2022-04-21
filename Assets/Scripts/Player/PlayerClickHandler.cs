using System;
using Trell.CombatSystem;
using Trell.Core.Input;
using UnityEngine;

namespace Trell.Player
{
    public class PlayerClickHandler : MonoBehaviour
    {
        [TagField]
        [SerializeField] private string _enemyTag;

        public event Action<Health> HittedEnemyChanged;

        public Vector3 PositionToMove { get; private set; }

        private Health _hittedEnemy;
        private Camera _camera;
        private bool _isMouseDown => InputHandler.Instace.IsMouseDown;


        private void Awake()
        {
            _camera = Camera.main;
            PositionToMove = transform.position;
        }

        private void Update()
        {
            if (_isMouseDown)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] hits = Physics.RaycastAll(ray);

                if (hits.Length > 0)
                {
                    Health tempEnemy = null;
                    PositionToMove = hits[0].point;
                    foreach (var hit in hits)
                    {
                        if (hit.transform.CompareTag(_enemyTag))
                        {
                            hit.transform.TryGetComponent(out tempEnemy);
                            if (tempEnemy.IsDied)
                            {
                                tempEnemy = null;
                                continue;
                            }
                            break;
                        }
                    }
                    TryInvokeHittedEnemyChanged(tempEnemy);
                    return;
                }
                TryInvokeHittedEnemyChanged(null);
            }
        }

        private void EnemyHealthDownToZeroHandle()
        {
            _hittedEnemy.DownToZero -= EnemyHealthDownToZeroHandle;
            PositionToMove = transform.position;
            TryInvokeHittedEnemyChanged(null);
        }

        private bool TryInvokeHittedEnemyChanged(Health enemy)
        {
            if (_hittedEnemy != enemy)
            {
                HittedEnemyChanged?.Invoke(enemy);

                if (_hittedEnemy != null)
                {
                    _hittedEnemy.DownToZero -= EnemyHealthDownToZeroHandle;
                }

                _hittedEnemy = enemy;

                if(_hittedEnemy != null)
                {
                    _hittedEnemy.DownToZero += EnemyHealthDownToZeroHandle;
                }
                return true;
            }
            return false;
        }
    }
}