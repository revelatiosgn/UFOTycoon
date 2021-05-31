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
    /// <summary>
    /// Trigger for capturing humans
    /// </summary>
    public class CaptureZone : MonoBehaviour
    {
        List<HumanController> targets = new List<HumanController>();
        HumanController target = null;
        float captureTime = 0f;

        UFOData ufoData;
        CaptureHumanCommand.Factory captureHuman;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, CaptureHumanCommand.Factory captureHuman, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.captureHuman = captureHuman;
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
            TryCapture();
            UpdateSize();
        }

        void OnTriggerEnter(Collider other)
        {
            HumanController human = other.GetComponent<HumanController>();
            targets.Add(human);
        }
        
        void OnTriggerExit(Collider other)
        {
            HumanController captureTarget = other.GetComponent<HumanController>();
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

        HumanController GetCaptureTarget()
        {
            return targets.Find((HumanController human) => {
                if (ufoData.Cargo + human.HumanConfig.weight <= ufoData.UFOConfig.maxCargo.Value)
                    return true;
                return false;
            });
        }

        void TryCapture()
        {
            if (ufoData.Cargo == ufoData.UFOConfig.maxCargo.Value)
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
            target.SetCaptureProgress(captureTime / ufoData.UFOConfig.captureTime.Value * 100f);

            if (captureTime >= ufoData.UFOConfig.captureTime.Value)
            {
                captureHuman.Create(target).Execute();
                target = null;
            }
        }

        void UpdateSize()
        {
            transform.localScale = Vector3.one * (ufoData.UFOConfig.captureSize.Value / ufoData.UFOConfig.captureSize.BaseValue);
        }
    }
}

