using UnityEngine;
using Zenject;

using UFOT.Human;
using UFOT.Data;
using UFOT.Commands;
using UFOT.Signals;
using UFOT.UI;

namespace UFOT.Core
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] GameObject shopProductPrefab;
        [SerializeField] Transform shopProductParent;

        public override void InstallBindings()
        {
            Container.BindFactory<ShopProduct, ShopProductPanel, ShopProductPanel.Factory>()
                .FromComponentInNewPrefab(shopProductPrefab)
                .UnderTransform(shopProductParent.transform);
        }
    }
}