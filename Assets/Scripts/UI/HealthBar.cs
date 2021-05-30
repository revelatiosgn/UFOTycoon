using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

using UFOT.Data;

namespace UFOT.UI
{
    public class HealthBar : UFODataView
    {
        [SerializeField] ProgressBar progressBar;
        [SerializeField] TMP_Text value;

        protected override void UpdateView()
        {
            int current = Mathf.FloorToInt(ufoData.Health);
            int max = Mathf.FloorToInt(ufoData.UFOConfig.maxHealth.Value);
            value.text =  $"{current} / {max}";

            progressBar.MaxValue = max;
            progressBar.SetProgress(ufoData.Health);
        }
    }
}

