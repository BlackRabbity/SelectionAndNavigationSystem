using UnityEngine;


namespace SelectionAndNavigationSystem.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        void LateUpdate()
        {
            transform.position = target.position;
        }

        public void ChangeCameraTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
