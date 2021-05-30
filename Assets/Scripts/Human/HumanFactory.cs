using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Data;
using UFOT.UI;
using Zenject;

namespace UFOT.Human
{
    public class HumanFactory : IFactory<Transform, HumanActor>
    {
        DiContainer container;
        HumansConfig humansConfig;

        public HumanFactory(DiContainer container, HumansConfig humansConfig)
        {
            this.container = container;
            this.humansConfig = humansConfig;
        }

        public HumanActor Create(Transform parent)
        {
            if (humansConfig.prefabs.Count == 0)
                return null;

            int index = Random.Range(0, humansConfig.prefabs.Count);

            return container.InstantiatePrefabForComponent<HumanActor>(humansConfig.prefabs[index], parent);
        }
    }
}

