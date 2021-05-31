using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Zenject;

using UFOT.Signals;
using UFOT.Data;

namespace UFOT.Human
{
    /// <summary>
    /// Human Pool object
    /// </summary>
    public class HumanPool
    {
        Dictionary<HumanConfig, Queue<HumanController>> dictionary = new Dictionary<HumanConfig, Queue<HumanController>>();

        SignalBus signalBus;

        public HumanPool(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void Push(HumanController target)
        {
            if (!dictionary.ContainsKey(target.HumanConfig))
                dictionary.Add(target.HumanConfig, new Queue<HumanController>());

            target.gameObject.SetActive(false);
            dictionary[target.HumanConfig].Enqueue(target);

            signalBus.Fire(new HumanDestroyedSignal() { human = target });
        }

        public HumanController Pull(HumanConfig humanConfig)
        {
            Queue<HumanController> queue;
            if (dictionary.TryGetValue(humanConfig, out queue))
            {
                if (queue.Count > 0)
                {
                    HumanController human = queue.Dequeue();
                    human.gameObject.SetActive(true);
                    return human;
                }
            }

            return null;
        }
    }
}


