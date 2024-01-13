using SelectionAndNavigationSystem.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerSelection : MonoBehaviour
    {
        [SerializeField]
        FollowCamera followCamera;

        private Transform[] playerCharacters;
        private Transform currentPlayerCharacter;

        void Start()
        {
            GetPlayerCharacters();
            if (playerCharacters != null)
            {
                currentPlayerCharacter = playerCharacters[0];
                ActivatePlayerCharacter();
            }
        }

        private void GetPlayerCharacters()
        {
            var transforms = GetComponentsInChildren<Transform>();
            playerCharacters = new Transform[transforms.Length - 1];
            int index = 0;
            foreach (var transform in transforms)
            {
                if (transform != this.transform)
                {
                    playerCharacters[index] = transform;
                    index++;
                }
            }
        }
        private void ActivatePlayerCharacter()
        {
            currentPlayerCharacter.GetComponent<PlayerController>().isActive = true;
            followCamera.ChangeCameraTarget(currentPlayerCharacter);
        }

        public void ChangePlayerCharacter(int newPlayerCharacterIndex)
        {
            currentPlayerCharacter.GetComponent<PlayerController>().isActive = false;
            currentPlayerCharacter = playerCharacters[newPlayerCharacterIndex];
            ActivatePlayerCharacter();
        }
    }
}
