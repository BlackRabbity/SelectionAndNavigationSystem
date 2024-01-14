using SelectionAndNavigationSystem.Control;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionAndNavigationSystem.GUI
{
    [RequireComponent(typeof(Button))]
    public class PlayerSelectionManager : MonoBehaviour
    {
        PlayerSelection playerSelection;
        Button[] changePlayerCharacterButtons;
        
        void Start()
        {
            playerSelection = GameObject.FindGameObjectWithTag("Players").GetComponent<PlayerSelection>();
            GetPlayerSwapButtons();
            if(IsNumberOfCharactersSameAsButtons())
            {
                SetButtonsBasedOnPlayerCharacters();
            }
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
        private bool IsNumberOfCharactersSameAsButtons()
        {
            return playerSelection.PlayerCharacters.Length == changePlayerCharacterButtons.Length;
        }
        private void SetButtonsBasedOnPlayerCharacters()
        {
            for (int i = 0; i < changePlayerCharacterButtons.Length; i++)
            {
                int copy = i;
                changePlayerCharacterButtons[copy].onClick.AddListener(delegate { playerSelection.SetNewPlayerCharacter(copy); });
                changePlayerCharacterButtons[copy].GetComponentInChildren<Text>().text = playerSelection.PlayerCharacters[copy].name;
            }
        }
    }
}
