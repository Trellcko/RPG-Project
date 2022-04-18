using UnityEngine;

namespace Trell.CombatSystem
{
    public class Attacking : MonoBehaviour
    {
        [SerializeField] private float _damage;
        public void Attack(Health health)
        {
            health.TakeDamage(_damage);
        }
    }
}