using UnityEngine;


namespace SelectionAndNavigationSystem.Core
{
    public class Attributes : MonoBehaviour
    {
        [SerializeField]
        float maxAttributeValue = 100;
        [SerializeField]
        float minAttributeValue = 1;

        public float speed;
        public float maneuverability;
        public float stamina;

        private void Start()
        {
            speed = GetRandomAttributeValue();
            maneuverability = GetRandomAttributeValue();
            stamina = GetRandomAttributeValue();
        }

        private float GetRandomAttributeValue()
        {
            return Random.Range(minAttributeValue, maxAttributeValue);
        }
    }
}
