using UnityEngine;
using Zenject;

using UFOT.Human;
using UFOT.Data;
using UFOT.Signals;

namespace UFOT.Commands
{
    public class CaptureHumanCommand : ICommand
    {
        HumanActor target;
        UFOData ufoData;
        HumanPool humanPool;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, HumanPool humanPool, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.humanPool = humanPool;
            this.signalBus = signalBus;
        }

        public CaptureHumanCommand(HumanActor target)
        {
            this.target = target;
        }

        public void Execute()
        {
            if (target == null)
                return;

            if (ufoData.Cargo + target.HumanConfig.weight > ufoData.UFOConfig.maxCargo.Value)
                return;

            humanPool.Push(target);
            ufoData.Cargo += target.HumanConfig.weight;
            ufoData.Reward += target.HumanConfig.reward;

            signalBus.Fire<UfoDataUpdatedSignal>();
        }

        public class Factory : PlaceholderFactory<HumanActor, CaptureHumanCommand>
        {
        }
    }
}

