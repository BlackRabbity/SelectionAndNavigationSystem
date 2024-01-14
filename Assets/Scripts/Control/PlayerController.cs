using SelectionAndNavigationSystem.Movement;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public bool IsActive = false;

        float distanceToStopFollow = 3f;
        Transform followTarget;

        void Update()
        {
            if (InteractWithUI()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithMovement()
        {
            if (IsActive)
            {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
                if (hasHit && Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                    return true;
                }
            } else if (followTarget != null)
            {
                if(!IsInRangeToStopFollow())
                {
                    GetComponent<Mover>().MoveTo(followTarget.position);
                    return true;
                }
                GetComponent<Mover>().Cancel();
                return true;
            }
            return false;
        }

        private bool InteractWithUI()
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }
            return false;
        }
        private bool IsInRangeToStopFollow()
        {
            return Vector3.Distance(followTarget.position, transform.position) < distanceToStopFollow;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void SetNewFollowTarget(Transform newFollowTarget)
        {
            followTarget = newFollowTarget;
        }
    }
}
