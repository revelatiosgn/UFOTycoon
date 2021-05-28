using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/UFO Config Value")]
    public class UFOConfigValue : ScriptableObject
    {
        [SerializeField] string title;
        public string Title { get => title; }

        [SerializeField] float baseValue;
        public float BaseValue { get => baseValue; }

        [SerializeField] float currentValue;
        public float Value { get => currentValue; set => currentValue = value; }

        void OnEnable()
        {
            currentValue = baseValue;
        }
    }
}

