using UnityEngine;
using Zenject;

using UFOT.Data;

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

            shopProduct.Config.Value += shopProduct.Config.Value * (shopProduct.Percent * 0.01f);
            signalBus.Fire<UFOT.Signals.UfoDataUpdatedSignal>();
        }

        public class Factory : PlaceholderFactory<ShopProduct, PurchaseCommand>
        {
        }
    }
}

