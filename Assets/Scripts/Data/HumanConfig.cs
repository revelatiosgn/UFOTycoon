using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/Human Config")]
    public class HumanConfig : ScriptableObject
    {
        public int weight = 70;
        public int reward = 35;
    }
}

