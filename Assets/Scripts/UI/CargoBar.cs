using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using UFOT.Data;

namespace UFOT.UI
{
    public class CargoBar : MonoBehaviour
    {
        TMP_Text text;
        UFOData ufoData;

        [Inject]
        void Construct(UFOData ufoData)
        {
            this.ufoData = ufoData;
        }

        void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            int current = Mathf.FloorToInt(ufoData.Cargo);
            int max = Mathf.FloorToInt(ufoData.UFOConfig.Cargo.Value);
            text.text = $"{current} / {max}";
        }
    }
}

