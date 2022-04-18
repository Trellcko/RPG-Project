using Trell.CombatSystem;
using Trell.Core.Input;
using UnityEngine;

namespace Trell.Player
{
    public class PlayerClickHandler : MonoBehaviour
    {
        [TagField]
        [SerializeField] private string _enemyTag;

        
        public Vector3 LastClickedPosition { get; private set; }

        public Health HittedEnemy { get; private set; }

        private Camera _camera;
        private bool _isMouseDown => InputHandler.Instace.IsMouseDown;


        private void Awake()
        {
            _camera = Camera.main;
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
                    Vector3 previousClickPosition = LastClickedPosition;
                    LastClickedPosition = hits[0].point;
                    foreach (var hit in hits)
                    {
                        if (hit.transform.CompareTag(_enemyTag))
                        {
                            hit.transform.TryGetComponent(out tempEnemy);
                            if(tempEnemy.IsDied)
                            {
                                tempEnemy = null;
                                continue;
                            }
                            LastClickedPosition = previousClickPosition;
                            break;
                        }
                    }
                    HittedEnemy = tempEnemy;
                    return;   
                }
                HittedEnemy = null;
            }
        }
    }
}