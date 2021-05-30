using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.Commands;

namespace UFOT.UI
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] GameObject productsList;
        [SerializeField] GameObject productPrefab;
        [SerializeField] ShopConfig shopConfig;

        ShopProductPanel.Factory product;
        PauseCommand.Factory pause;

        [Inject]
        void Construct(ShopProductPanel.Factory product, PauseCommand.Factory pause)
        {
            this.product = product;
            this.pause = pause;
        }

        void OnEnable()
        {
            PopulateProducts();
            pause.Create(true).Execute();
        }

        void OnDisable()
        {
            PopulateProducts();
            pause.Create(false).Execute();
        }

        void PopulateProducts()
        {
            if (productsList.transform.childCount != shopConfig.Products.Count)
            {
                foreach (Transform child in productsList.transform)
                    GameObject.Destroy(child.gameObject);

                shopConfig.Products.ForEach(shopProduct => {
                    product.Create(shopProduct);
                });
            }
            else
            {
                for (int i = 0; i < shopConfig.Products.Count; i++)
                    productsList.transform.GetChild(i).GetComponent<ShopProductPanel>().SetProduct(shopConfig.Products[i]);
            }
        }
    }
}

