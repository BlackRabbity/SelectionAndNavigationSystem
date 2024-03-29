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

        public void SetNewCameraTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
