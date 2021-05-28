using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/UFO Config")]
    public class UFOConfig : ScriptableObject
    {
        public int startCoins = 500;

        public UFOConfigValue Speed;
        public UFOConfigValue Cargo;
    }
}

