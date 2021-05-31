using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    /// <summary>
    /// Human configuration SO
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Human Config")]
    public class HumanConfig : ScriptableObject
    {
        public float weight = 70;
        public int reward = 35;
        public float walkSpeed = 1f;
        public float runSpeed = 1.5f;
        public float idleTime = 3f;
        public float walkChance = 10f;
        public float returnChance = 1f;
    }
}

