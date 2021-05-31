using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UFOT.UI
{
    /// <summary>
    /// Base UI element for progress bar
    /// </summary>
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] Slider slider;

        public float MaxValue { get => slider.maxValue; set => slider.maxValue = value; }
        public float MinValue { get => slider.minValue; set => slider.minValue = value; }

        public void SetProgress(float progress)
        {
            slider.value = progress;
            slider.fillRect.gameObject.SetActive(progress > 0f);
        }
    }
}

