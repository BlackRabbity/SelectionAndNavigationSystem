using SelectionAndNavigationSystem.Core;
using UnityEngine;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerSelection : MonoBehaviour
    {
        [SerializeField]
        FollowCamera followCamera;

        private Transform currentPlayerCharacter;

        public Transform[] PlayerCharacters;

        void Start()
        {
            GetPlayerCharacters();
            if (PlayerCharacters != null)
            {
                currentPlayerCharacter = PlayerCharacters[0];
                ActivatePlayerCharacter();
            }
        }

        private void GetPlayerCharacters()
        {
            var transforms = GetComponentsInChildren<Transform>();
            PlayerCharacters = new Transform[transforms.Length - 1];
            int index = 0;
            foreach (var transform in transforms)
            {
                if (transform != this.transform)
                {
                    PlayerCharacters[index] = transform;
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
            currentPlayerCharacter = PlayerCharacters[newPlayerCharacterIndex];
            ActivatePlayerCharacter();
        }
    }
}
