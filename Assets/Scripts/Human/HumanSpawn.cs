using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;

using UFOT.Signals;
using UFOT.Data;

namespace UFOT.Human
{
    /// <summary>
    /// Spawns random human from list with some delay
    /// </summary>
    public class HumanSpawn : MonoBehaviour
    {
        [System.Serializable]
        public class SpawnItem
        {
            public HumanController prefab;
            public float chance;
        }

        [SerializeField] List<SpawnItem> items;
        [SerializeField] float spawnDelay = 5f;

        float spawnTime = 0f;
        float chanceSum = 0f;

        HumanPool humanPool;

        [Inject]
        void Construct(HumanPool humanPool)
        {
            this.humanPool = humanPool;
        }

        void Awake()
        {
            chanceSum = items.Sum(item => item.chance);
        }

        void Update()
        {
            TrySpawn();
            spawnTime += Time.deltaTime;
        }

        void TrySpawn()
        {
            if (spawnTime < spawnDelay)
                return;

            spawnTime = 0f;

            HumanController humanController = humanPool.Pull(GetRandomHuman().HumanConfig);
            if (humanController != null)
                humanController.Warp(transform.position);
        }

        public HumanController GetRandomHuman()
        {
            float rnd = Random.Range(0f, chanceSum);
            for (int i = 0; i < items.Count; i++)
            {
                SpawnItem item = items[i];
                if (rnd < item.chance)
                    return item.prefab;
                rnd -= item.chance;
            }

            return null;
        }
    }
}