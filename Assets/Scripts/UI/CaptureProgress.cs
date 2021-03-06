using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UFOT.UI
{
    /// <summary>
    /// UI element represents human capturing process
    /// </summary>
    public class CaptureProgress : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;
        [SerializeField] TMP_Text value;

        public void SetProgress(float percent)
        {
            value.text = Mathf.FloorToInt(percent).ToString() + "%";
            progressBar.SetProgress(percent);
        }
    }
}

