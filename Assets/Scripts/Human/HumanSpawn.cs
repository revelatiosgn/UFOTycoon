using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Signals;

namespace UFOT.Human
{
    public class HumanSpawn : MonoBehaviour
    {
        SignalBus signalBus;

        [Inject]
        void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        void Start()
        {
            signalBus.Fire(new RegisterHumanSpawnSignal() { humanSpawn = this });
        }
    }
}
