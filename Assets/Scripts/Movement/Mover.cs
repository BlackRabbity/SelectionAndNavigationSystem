using UnityEngine;
using UnityEngine.AI;


namespace SelectionAndNavigationSystem.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
        }
    }
}
