using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace UFOT.Human
{
    /// <summary>
    /// Human Zenject factory
    /// </summary>
    public class HumanFactory : IFactory<GameObject, Transform, HumanController>
    {
        DiContainer container;

        public HumanFactory(DiContainer container)
        {
            this.container = container;
        }

        public HumanController Create(GameObject prefab, Transform parent)
        {
            return container.InstantiatePrefabForComponent<HumanController>(prefab, parent);
        }
    }
}

