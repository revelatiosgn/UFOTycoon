using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

using Zenject;
using UFOT.Signals;

namespace UFOT.Human
{
    public class HumanPool
    {
        Queue<HumanActor> queue = new Queue<HumanActor>();

        SignalBus signalBus;

        [Inject]
        void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void Push(HumanActor target)
        {
            target.gameObject.SetActive(false);
            queue.Enqueue(target);

            signalBus.Fire(new HumanDestroyedSignal() { human = target });
        }

        public HumanActor Pull()
        {
            if (queue.Count == 0)
                return null;

            HumanActor human = queue.Dequeue();
            human.gameObject.SetActive(true);
            return human;
        }
    }
}


