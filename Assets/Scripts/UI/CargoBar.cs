using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using UFOT.Data;
using UFOT.Signals;

namespace UFOT.UI
{
    /// <summary>
    /// UI element represents cargo fill and reward
    /// </summary>
    public class CargoBar : UFODataView
    {
        [SerializeField] ProgressBar cargoProgress;
        [SerializeField] TMP_Text cargoFill;
        [SerializeField] TMP_Text reward;

        protected override void UpdateView()
        {
            cargoProgress.MaxValue = ufoData.UFOConfig.maxCargo.Value;
            cargoProgress.SetProgress(ufoData.Cargo);

            int current = Mathf.FloorToInt(ufoData.Cargo);
            int max = Mathf.FloorToInt(ufoData.UFOConfig.maxCargo.Value);
            cargoFill.text = $"{current} / {max}";

            reward.text = ufoData.Reward.ToString();
        }
    }
}

