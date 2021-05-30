using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.Signals;

namespace UFOT.Commands
{
    public class PurchaseCommand : ICommand
    {
        ShopProduct shopProduct;
        UFOData ufoData;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.signalBus = signalBus;
        }

        public PurchaseCommand(ShopProduct shopProduct)
        {
            this.shopProduct = shopProduct;
        }

        public void Execute()
        {
            if (shopProduct == null)
                return;

            if (ufoData.Coins < shopProduct.Cost)
                return;

            ufoData.Coins -= shopProduct.Cost;
            shopProduct.Config.Value += shopProduct.Config.Value * (shopProduct.Percent * 0.01f);
            
            signalBus.Fire<UfoDataUpdatedSignal>();
        }

        public class Factory : PlaceholderFactory<ShopProduct, PurchaseCommand>
        {
        }
    }
}

