using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Commands;

namespace UFOT.UFO
{
    public class BaseZone : MonoBehaviour
    {
        UnloadHumansCommand.Factory commandFactory;

        [Inject]
        void Construct(UnloadHumansCommand.Factory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        void OnTriggerEnter(Collider other)
        {
            commandFactory.Create().Execute();
        }
    }
}


