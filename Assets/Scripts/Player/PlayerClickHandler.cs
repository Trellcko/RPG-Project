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

        public event Action<Vector3> LastClickPositionChanged;
        public event Action<Health> HittedEnemyChanging;
        public Vector3 LastClickPosition { get; private set; }

        public Health HittedEnemy { get; private set; }
        private Camera _camera;
        private bool _isMouseDown => InputHandler.Instace.IsMouseDown;


        private void Awake()
        {
            _camera = Camera.main;
            LastClickPosition = transform.position;
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
                    LastClickPosition = hits[0].point;
                    LastClickPositionChanged?.Invoke(LastClickPosition);
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

        private bool TryInvokeHittedEnemyChanged(Health enemy)
        {
            if (HittedEnemy != enemy)
            {
                HittedEnemyChanging?.Invoke(enemy);
                HittedEnemy = enemy;
                return true;
            }
            return false;
        }
    }

}