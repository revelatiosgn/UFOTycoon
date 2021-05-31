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
    /// <summary>
    /// UI element represents ShopProduct
    /// </summary>
    public class ShopProductPanel : UFODataView
    {
        [SerializeField] TMP_Text title;
        [SerializeField] TMP_Text value;
        [SerializeField] TMP_Text price;
        [SerializeField] Button buy;

        ShopProduct shopProduct;
        PurchaseCommand.Factory purchase;

        [Inject]
        void Construct(ShopProduct shopProduct, PurchaseCommand.Factory purchase)
        {
            this.shopProduct = shopProduct;
            this.purchase = purchase;
        }

        public void SetProduct(ShopProduct shopProduct)
        {
            this.shopProduct = shopProduct;
            UpdateView();
        }

        public void Purchase()
        {
            purchase.Create(shopProduct).Execute();
        }

        protected override void UpdateView()
        {
            if (shopProduct == null)
                return;

            title.text = shopProduct.Config.Title;

            int currentValue = Mathf.FloorToInt(shopProduct.Config.Value);
            int nextValue = currentValue + Mathf.FloorToInt(shopProduct.Config.Value * shopProduct.Percent * 0.01f);
            value.text = $"{currentValue}->{nextValue}";
            price.text = shopProduct.Cost.ToString();

            buy.interactable = ufoData.Coins >= shopProduct.Cost;
        }

        public class Factory : PlaceholderFactory<ShopProduct, ShopProductPanel>
        {
        }
    }
}

