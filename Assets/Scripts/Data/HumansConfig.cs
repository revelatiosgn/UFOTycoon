using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/Humans Config")]
    public class HumansConfig : ScriptableObject
    {
        public int maxInstances = 100;
        public float spawnDelay = 5f;
        public List<GameObject> prefabs;
    }
}

