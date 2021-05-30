using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Commands;
using UFOT.Signals;

namespace UFOT.UFO
{
    public class BaseZone : MonoBehaviour
    {
        UnloadHumansCommand.Factory unloadHumans;
        SignalBus signalBus;

        [Inject]
        void Construct(UnloadHumansCommand.Factory unloadHumans, SignalBus signalBus)
        {
            this.unloadHumans = unloadHumans;
            this.signalBus = signalBus;
        }

        void OnTriggerEnter(Collider other)
        {
            unloadHumans.Create().Execute();
            signalBus.Fire<BaseEnterSignal>();
        }

        void OnTriggerExit(Collider other)
        {
            signalBus.Fire<BaseExitSignal>();
        }
    }
}


