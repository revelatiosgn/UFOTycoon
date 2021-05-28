using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UFOT.UI
{
    public class HealthBar : MonoBehaviour
    {
        TMP_Text text;

        void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            // text.text =  $"{userData.Health} / {userData.MaxHealth}";
        }
    }
}

