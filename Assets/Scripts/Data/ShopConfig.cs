using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace UFOT.Data
{
    /// <summary>
    /// Shop configuration SO
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Shop Config")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] List<ShopProduct> products;
        public List<ShopProduct> Products { get => products; }
    }

    /// <summary>
    /// Shop product configuration SO
    /// </summary>
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
