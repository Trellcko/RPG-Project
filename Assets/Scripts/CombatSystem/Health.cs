using Trell.Animation.Character;
using UnityEngine;

namespace Trell.CombatSystem
{
	public class Health : MonoBehaviour
	{
		[SerializeField] private float _health = 100f;

        [SerializeField] private DeathAnimator _deathAnimator;

        public bool IsDied { get; private set; } = false;

		private float _currentHealth;



        private void OnEnable()
        {
            _deathAnimator.Died += Die;
        }

        private void OnDisable()
        {
            _deathAnimator.Died -= Die;   
        }

        private void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _health);
            if(_currentHealth == 0)
            {
                IsDied = true;
                _deathAnimator.Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}