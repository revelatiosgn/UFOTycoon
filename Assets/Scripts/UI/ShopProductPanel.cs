using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

using UFOT.Data;
using UFOT.Commands;
using UFOT.Signals;

namespace UFOT.UI
{
    public class ShopProductPanel : MonoBehaviour
    {
        [SerializeField] TMP_Text title;
        [SerializeField] TMP_Text value;
        [SerializeField] TMP_Text price;
        [SerializeField] Button buy;

        ShopProduct shopProduct;

        UFOData ufoData;
        PurchaseCommand.Factory commandFactory;
        SignalBus signalBus;

        [Inject]
        void Construct(UFOData testData, PurchaseCommand.Factory commandFactory, SignalBus signalBus)
        {
            this.ufoData = testData;
            this.commandFactory = commandFactory;
            this.signalBus = signalBus;
        }

        void OnEnable()
        {
            signalBus.Subscribe<UfoDataUpdatedSignal>(UpdateInfo);
        }

        void OnDisable()
        {
            signalBus.Unsubscribe<UfoDataUpdatedSignal>(UpdateInfo);
        }

        public void SetProduct(ShopProduct shopProduct)
        {
            this.shopProduct = shopProduct;
            UpdateInfo();
        }

        public void Purchase()
        {
            commandFactory.Create(shopProduct).Execute();
        }

        void UpdateInfo()
        {
            title.text = shopProduct.Config.Title;

            int currentValue = Mathf.FloorToInt(shopProduct.Config.Value);
            int nextValue = currentValue + Mathf.FloorToInt(shopProduct.Config.Value * shopProduct.Percent * 0.01f);
            value.text = $"{currentValue}->{nextValue}";
            price.text = shopProduct.Cost.ToString();

            buy.interactable = ufoData.Coins >= shopProduct.Cost;
        }
    }
}

