using UnityEngine;


namespace SelectionAndNavigationSystem.Core
{
    public class Attributes : MonoBehaviour
    {
        [SerializeField]
        float maxAttributeValue = 100;
        [SerializeField]
        float minAttributeValue = 1;

        public float Speed;
        public float Maneuverability;
        public float Stamina;

        void Start()
        {
            Speed = GetRandomAttributeValue();
            Maneuverability = GetRandomAttributeValue();
            Stamina = GetRandomAttributeValue();
        }

        private float GetRandomAttributeValue()
        {
            return Random.Range(minAttributeValue, maxAttributeValue);
        }
    }
}
