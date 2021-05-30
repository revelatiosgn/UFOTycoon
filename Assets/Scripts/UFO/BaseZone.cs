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
        UnloadHumansCommand.Factory commandFactory;
        SignalBus signalBus;

        [Inject]
        void Construct(UnloadHumansCommand.Factory commandFactory, SignalBus signalBus)
        {
            this.commandFactory = commandFactory;
            this.signalBus = signalBus;
        }

        void OnTriggerEnter(Collider other)
        {
            commandFactory.Create().Execute();
            signalBus.Fire<BaseEnterSignal>();
        }

        void OnTriggerExit(Collider other)
        {
            signalBus.Fire<BaseExitSignal>();
        }
    }
}


