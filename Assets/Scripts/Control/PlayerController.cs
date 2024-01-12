using SelectionAndNavigationSystem.Movement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            if (InteractWithUI()) return;
            if (InteractWithMovement()) return;
        }


        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                }
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

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
