using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.Signals;

namespace UFOT.Commands
{
    /// <summary>
    /// Empty UFO cargo and update coins
    /// </summary>
    public class UnloadHumansCommand : ICommand
    {
        UFOData ufoData;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.signalBus = signalBus;
        }

        public UnloadHumansCommand()
        {
        }

        public void Execute()
        {
            ufoData.Coins += ufoData.Reward;
            ufoData.Cargo = 0;
            ufoData.Reward = 0;

            signalBus.Fire<UfoDataUpdatedSignal>();
        }

        public class Factory : PlaceholderFactory<UnloadHumansCommand>
        {
        }
    }
}

