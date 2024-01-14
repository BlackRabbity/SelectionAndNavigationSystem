using SelectionAndNavigationSystem.Movement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] 
        public bool isActive = false;

        void Update()
        {
            if (InteractWithUI()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithMovement()
        {
            if (isActive)
            {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
                if (hasHit && Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                    return true;
                }
            } else
            {

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

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
