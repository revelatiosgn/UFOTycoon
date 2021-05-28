using UnityEngine;
using Zenject;

using UFOT.Data;

namespace UFOT.Commands
{
    public class UnloadHumansCommand : ICommand
    {
        UFOData ufoData;

        [Inject]
        void Construct(UFOData ufoData)
        {
            this.ufoData = ufoData;
        }

        public UnloadHumansCommand()
        {
        }

        public void Execute()
        {
            ufoData.Coins += ufoData.Reward;
            ufoData.Cargo = 0;
            ufoData.Reward = 0;
        }

        public class Factory : PlaceholderFactory<UnloadHumansCommand>
        {
        }
    }
}

