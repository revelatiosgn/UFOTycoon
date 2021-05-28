using UnityEngine;
using UnityEngine.Events;

namespace UFOT.Data
{
    public class UFOData
    {
        public UFOData(UFOConfig ufoConfig)
        {
            this.UFOConfig = ufoConfig;

            Coins = ufoConfig.startCoins;
        }

        public UFOConfig UFOConfig { get; private set; }

        public int Coins { get; set; }
        public int Cargo { get; set; }
        public int Reward { get; set; }
    }
}

