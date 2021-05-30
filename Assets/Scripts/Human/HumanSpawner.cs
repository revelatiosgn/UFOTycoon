using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Signals;

namespace UFOT.Human
{
    public class HumanSpawner : MonoBehaviour
    {
        [SerializeField] int maxHumans = 10;
        [SerializeField] List<GameObject> humanPrefabs;
        [SerializeField] float spawnDelay = 3f;

        List<HumanSpawn> spawns = new List<HumanSpawn>();
        float spawnTime = 0f;

        HumanPool humanPool;
        SignalBus signalBus;

        [Inject]
        void Construct(HumanPool humanPool, SignalBus signalBus)
        {
            this.humanPool = humanPool;
            this.signalBus = signalBus;
        }

        void OnEnable()
        {
            signalBus.Subscribe<RegisterHumanSpawnSignal>(OnRegisterHumanSpawn);
        }

        void OnDisable()
        {
            signalBus.Unsubscribe<RegisterHumanSpawnSignal>(OnRegisterHumanSpawn);
        }

        void Start()
        {
            int extraHumans = maxHumans - transform.childCount;
            for (int i = 0; i < extraHumans; i++)
            {
                GameObject randomPrefab = humanPrefabs[Random.Range(0, humanPrefabs.Count)];
                HumanActor human = Instantiate(randomPrefab, transform).GetComponent<HumanActor>();
                humanPool.Push(human);
            }
        }

        void Update()
        {
            TrySpawn();
            spawnTime += Time.deltaTime;
        }

        void OnRegisterHumanSpawn(RegisterHumanSpawnSignal signal)
        {
            spawns.Add(signal.humanSpawn);
        }

        void TrySpawn()
        {
            if (spawnTime < spawnDelay)
                return;

            spawnTime = 0f;

            HumanSpawn spawn = GetRandomSpawn();
            if (spawn == null)
                return;

            HumanActor human = humanPool.Pull();
            if (human == null)
                return;

            human.gameObject.transform.position = spawn.transform.position;
        }

        public HumanSpawn GetRandomSpawn()
        {
            if (spawns.Count == 0)
                return null;

            return spawns[Random.Range(0, spawns.Count)];
        }
    }
}

