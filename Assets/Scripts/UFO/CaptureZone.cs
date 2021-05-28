using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Signals;
using UFOT.Human;
using UFOT.Data;
using UFOT.Commands;

namespace UFOT.UFO
{
    public class CaptureZone : MonoBehaviour
    {
        [SerializeField] float captureTimeLimit = 2f;

        List<HumanActor> targets = new List<HumanActor>();
        HumanActor currentTarget = null;
        float captureTime = 0f;

        UFOData ufoData;
        CaptureHumanCommand.Factory commandFactory;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, CaptureHumanCommand.Factory commandFactory, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.commandFactory = commandFactory;
            this.signalBus = signalBus;
        }

        void OnEnable()
        {
            signalBus.Subscribe<HumanDestroyedSignal>(OnHumanDestroyed);
        }

        void OnDisable()
        {
            signalBus.Unsubscribe<HumanDestroyedSignal>(OnHumanDestroyed);
        }

        void Update()
        {
            if (ufoData.Cargo == ufoData.UFOConfig.Cargo.Value)
                return;

            if (currentTarget == null)
            {
                captureTime = 0f;

                if (targets.Count == 0)
                    return;

                currentTarget = GetCaptureTarget();
            }

            captureTime += Time.deltaTime;

            if (captureTime >= captureTimeLimit)
            {
                commandFactory.Create(currentTarget).Execute();
                currentTarget = null;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            HumanActor human = other.GetComponent<HumanActor>();
            targets.Add(human);
        }
        
        void OnTriggerExit(Collider other)
        {
            HumanActor captureTarget = other.GetComponent<HumanActor>();
            targets.Remove(captureTarget);
            if (currentTarget == captureTarget)
                currentTarget = null;
        }

        void OnHumanDestroyed(HumanDestroyedSignal signal)
        {
            targets.Remove(signal.human);
            if (currentTarget == signal.human)
                currentTarget = null;
        }

        HumanActor GetCaptureTarget()
        {
            return targets.Find((HumanActor human) => {
                if (ufoData.Cargo + human.HumanConfig.weight <= ufoData.UFOConfig.Cargo.Value)
                    return true;
                return false;
            });
        }
    }
}

