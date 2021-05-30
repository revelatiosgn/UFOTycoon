using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;

namespace UFOT.UFO
{
    public class UFOShip : MonoBehaviour
    {
        UFOData ufoData;

        [Inject]
        void Construct(UFOData ufoData)
        {
            this.ufoData = ufoData;
        }

        void Update()
        {
            transform.localScale = Vector3.one * (this.ufoData.UFOConfig.shipSize.Value / this.ufoData.UFOConfig.shipSize.BaseValue);
        }
    }
}

