using SelectionAndNavigationSystem.Core;
using SelectionAndNavigationSystem.Movement;
using UnityEngine;

namespace SelectionAndNavigationSystem.Control
{
    public class PlayerSelection : MonoBehaviour
    {
        [SerializeField]
        FollowCamera followCamera;

        Transform currentPlayerCharacter;

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
            currentPlayerCharacter.GetComponent<PlayerController>().IsActive = true;
            followCamera.SetNewCameraTarget(currentPlayerCharacter);
            foreach (var playerCharacter in PlayerCharacters)
            {
                playerCharacter.GetComponent<PlayerController>().SetNewFollowTarget(currentPlayerCharacter);
                playerCharacter.GetComponent<Mover>().Cancel();
            };
        }

        public void SetNewPlayerCharacter(int newPlayerCharacterIndex)
        {
            currentPlayerCharacter.GetComponent<PlayerController>().IsActive = false;
            currentPlayerCharacter = PlayerCharacters[newPlayerCharacterIndex];
            ActivatePlayerCharacter();
        }
    }
}
