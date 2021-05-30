using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Data;
using UFOT.UI;
using Zenject;

namespace UFOT.Human
{
    public class HumanActor : MonoBehaviour
    {
        [SerializeField] HumanConfig humanConfig;
        public HumanConfig HumanConfig { get => humanConfig; }

        [SerializeField] CaptureProgress captureProgress;

        void OnEnable()
        {
            SetCaptureProgress(0f);
        }

        public void SetCaptureProgress(float progress)
        {
            captureProgress.SetProgress(progress);
            captureProgress.gameObject.SetActive(progress > 0f);
        }

        public class Factory : PlaceholderFactory<Transform, HumanActor>
        {     
        }
    }
}

