using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.Signals;
using System;

namespace UFOT.UI
{
    /// <summary>
    /// UI element opens ShopPanel
    /// </summary>
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] GameObject button;

        protected SignalBus signalBus;

        [Inject]
        void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        void OnEnable()
        {
            signalBus.Subscribe<BaseEnterSignal>(OnBaseEnter);
            signalBus.Subscribe<BaseExitSignal>(OnBaseExit);
        }

        void OnDisable()
        {
            signalBus.Unsubscribe<BaseEnterSignal>(OnBaseEnter);
            signalBus.Unsubscribe<BaseExitSignal>(OnBaseExit);
        }

        void OnBaseEnter()
        {
            button.SetActive(true);
        }

        void OnBaseExit()
        {
            button.SetActive(false);
        }
    }
}

