using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;

namespace UFOT.UI
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] GameObject productsList;
        [SerializeField] GameObject productPrefab;
        [SerializeField] ShopConfig shopConfig;

        void OnEnable()
        {
            PopulateProducts();
        }

        void PopulateProducts()
        {
            if (productsList.transform.childCount != shopConfig.Products.Count)
            {
                foreach (Transform child in productsList.transform)
                    GameObject.Destroy(child.gameObject);

                shopConfig.Products.ForEach(shopProduct => {
                    Instantiate(productPrefab, productsList.transform);
                });
            }

            for (int i = 0; i < shopConfig.Products.Count; i++)
                productsList.transform.GetChild(i).GetComponent<ShopProductPanel>().SetProduct(shopConfig.Products[i]);
        }
    }
}

