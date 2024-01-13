using SelectionAndNavigationSystem.Control;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionAndNavigationSystem.GUI
{
    [RequireComponent(typeof(Button))]
    public class PlayerSelectionManager : MonoBehaviour
    {
        [SerializeField]
        PlayerSelection playerSelection;

        [SerializeField]
        Button[] changePlayerCharacterButtons; 
        void Start()
        {
            playerSelection = GameObject.FindGameObjectWithTag("Players").GetComponent<PlayerSelection>();
            GetPlayerSwapButtons();
            AddListenersForPlayerCharacterChange();
        }

        private void GetPlayerSwapButtons()
        {
            var objects = GameObject.FindGameObjectsWithTag("PlayerSwapButton");
            changePlayerCharacterButtons = new Button[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                changePlayerCharacterButtons[i] = objects[i].GetComponent<Button>();
            }
        }
        private void AddListenersForPlayerCharacterChange()
        {
            for (int i = 0; i < changePlayerCharacterButtons.Length; i++)
            {
                int copy = i;
                changePlayerCharacterButtons[copy].onClick.AddListener(delegate { playerSelection.ChangePlayerCharacter(copy); });
            }
        }
    }
}
