using UnityEngine;
using Zenject;

using UFOT.Human;
using UFOT.Data;

namespace UFOT.Commands
{
    public class CaptureHumanCommand : ICommand
    {
        HumanActor target;
        UFOData ufoData;
        HumanPool humanPool;

        [Inject]
        void Construct(UFOData ufoData, HumanPool humanPool)
        {
            this.ufoData = ufoData;
            this.humanPool = humanPool;
        }

        public CaptureHumanCommand(HumanActor target)
        {
            this.target = target;
        }

        public void Execute()
        {
            if (target == null)
                return;

            if (ufoData.Cargo + target.HumanConfig.weight > ufoData.UFOConfig.Cargo.Value)
                return;

            humanPool.Push(target);
            ufoData.Cargo += target.HumanConfig.weight;
            ufoData.Reward += target.HumanConfig.reward;
        }

        public class Factory : PlaceholderFactory<HumanActor, CaptureHumanCommand>
        {
        }
    }
}

