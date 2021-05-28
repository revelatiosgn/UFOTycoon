using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace UFOT.Data
{
    [CreateAssetMenu(menuName = "Data/Shop Config")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] List<ShopProduct> products;
        public List<ShopProduct> Products { get => products; }
    }

    [System.Serializable]
    public class ShopProduct
    {
        [SerializeField] UFOConfigValue config;
        [SerializeField] int cost;
        [SerializeField] float percent;

        public UFOConfigValue Config { get => config; }
        public int Cost { get => cost; }
        public float Percent { get => percent; }
    }
}
