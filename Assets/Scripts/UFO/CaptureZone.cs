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
        [SerializeField] float captureTimeLimit = 10f;

        List<HumanActor> targets = new List<HumanActor>();
        HumanActor target = null;
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

            if (target == null)
            {
                captureTime = 0f;

                if (targets.Count == 0)
                    return;

                target = GetCaptureTarget();
            }

            if (target == null)
                return;

            captureTime += Time.deltaTime;
            target.SetCaptureProgress(captureTime / captureTimeLimit * 100f);

            if (captureTime >= captureTimeLimit)
            {
                commandFactory.Create(target).Execute();
                target = null;
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
            if (target == captureTarget)
            {
                target.SetCaptureProgress(0f);
                target = null;
            }
        }

        void OnHumanDestroyed(HumanDestroyedSignal signal)
        {
            targets.Remove(signal.human);
            if (target == signal.human)
                target = null;
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

