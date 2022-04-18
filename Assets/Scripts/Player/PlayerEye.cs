using UnityEngine;

namespace Trell.Player
{
	public class PlayerEye : MonoBehaviour
	{
		[SerializeField] private PlayerAttackingHandler _playerAttackingHandler;
        [SerializeField] private PlayerClickHandler _playerClickHandler;

        private void Update()
        {
            if (_playerAttackingHandler.IsAttacking)
            {
                LookAtEnemy();
            }
        }

        private void LookAtEnemy()
        {
            transform.LookAt(_playerClickHandler.HittedEnemy.transform);
        }
    }
}