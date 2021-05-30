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
            Reward = 0;
            Cargo = 0f;
            Health = ufoConfig.maxHealth.Value;
        }

        public UFOConfig UFOConfig { get; private set; }

        public int Coins { get; set; }
        public int Reward { get; set; }
        public float Cargo { get; set; }
        public float Health { get; set; }
    }
}

