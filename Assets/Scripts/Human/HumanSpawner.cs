using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Signals;
using UFOT.Data;

namespace UFOT.Human
{
    public class HumanSpawner : MonoBehaviour
    {
        List<HumanSpawn> spawns = new List<HumanSpawn>();
        float spawnTime = 0f;

        HumanPool humanPool;
        HumanActor.Factory humanFactory;
        HumansConfig humansConfig;
        SignalBus signalBus;

        [Inject]
        void Construct(HumanPool humanPool, HumanActor.Factory humanFactory, HumansConfig humansConfig, SignalBus signalBus)
        {
            this.humanPool = humanPool;
            this.humanFactory = humanFactory;
            this.humansConfig = humansConfig;
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
            InstantiateHumans();
        }

        void Update()
        {
            TrySpawn();
            spawnTime += Time.deltaTime;
        }

        void InstantiateHumans()
        {
            int extraHumans = humansConfig.maxInstances;
            for (int i = 0; i < extraHumans; i++)
            {
                HumanActor human = humanFactory.Create(transform);
                humanPool.Push(human);
            }
        }

        void OnRegisterHumanSpawn(RegisterHumanSpawnSignal signal)
        {
            spawns.Add(signal.humanSpawn);
        }

        void TrySpawn()
        {
            if (spawnTime < humansConfig.spawnDelay)
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

