using UnityEngine;
using UnityEngine.AI;

namespace Trell.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {

        private Vector3 _target;

        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _target = transform.position;
        }

        public float GetSpeed()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
            return localVelocity.z;
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }

        public void SetTarget(Vector3 target)
        {
            _target = target;
            _navMeshAgent.isStopped = false;
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(_target);
        }

    }
}