using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

using UFOT.Data;
using UFOT.Signals;

namespace UFOT.UI
{   
    public class CoinsBar : UFODataView
    {
        [SerializeField] TMP_Text value;

        protected override void UpdateView()
        {
            value.text = ufoData.Coins.ToString();
        }
    }
}

