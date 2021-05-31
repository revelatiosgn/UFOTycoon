using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.UI;

namespace UFOT.Human
{
    /// <summary>
    /// Parent object for all humans
    /// </summary>
    public class HumanRoot : MonoBehaviour
    {
        [SerializeField] int maxHumans = 30;

        List<HumanSpawn> spawns = new List<HumanSpawn>();
        public List<HumanSpawn> Spawns { get => spawns; }

        HumanPool humanPool;
        HumanController.Factory humanFactory;

        [Inject]
        void Construct(HumanPool humanPool, HumanController.Factory humanFactory)
        {
            this.humanPool = humanPool;
            this.humanFactory = humanFactory;
        }

        void Start()
        {
            spawns.AddRange(FindObjectsOfType<HumanSpawn>());

            if (spawns.Count == 0)
                return;

            int extraHumans = maxHumans - transform.childCount;
            for (int i = 0; i < extraHumans; i++)
            {
                HumanSpawn rndSpawn = spawns[Random.Range(0, spawns.Count)];
                HumanController human = humanFactory.Create(rndSpawn.GetRandomHuman().gameObject, transform);
                humanPool.Push(human);
            }
        }
    }
}

