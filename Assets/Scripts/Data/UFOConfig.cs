using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/UFO Config")]
    public class UFOConfig : ScriptableObject
    {
        public int startCoins = 500;
        public float speedMultiplier = 0.1f;

        public UFOConfigValue speed;
        public UFOConfigValue maxCargo;
        public UFOConfigValue maxHealth;
        public UFOConfigValue shipSize;
        public UFOConfigValue captureSize;
        public UFOConfigValue captureTime;
    }
}

