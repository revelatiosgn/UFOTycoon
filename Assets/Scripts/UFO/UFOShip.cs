using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;

namespace UFOT.UFO
{
    /// <summary>
    /// Handle ship model size provided by UFOData
    /// </summary>
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
            transform.localScale = Vector3.one * (ufoData.UFOConfig.shipSize.Value / ufoData.UFOConfig.shipSize.BaseValue);
        }
    }
}

