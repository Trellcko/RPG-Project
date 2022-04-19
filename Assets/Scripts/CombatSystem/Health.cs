using System;
using UnityEngine;

namespace Trell.CombatSystem
{
	public class Health : MonoBehaviour
	{
		[SerializeField] private float _health = 100f;

        public event Action DownToZero;

		private float _currentHealth;

        public bool IsDied => _currentHealth <= 0;
        
        private void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _health);
            if(_currentHealth == 0)
            {
                DownToZero?.Invoke();
            }
        }
    }
}