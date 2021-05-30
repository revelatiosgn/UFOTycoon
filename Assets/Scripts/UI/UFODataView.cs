using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using UFOT.Data;
using UFOT.Signals;

namespace UFOT.UI
{
    public abstract class UFODataView : MonoBehaviour
    {
        protected UFOData ufoData;
        protected SignalBus signalBus;

        [Inject]
        void Construct(UFOData ufoData, SignalBus signalBus)
        {
            this.ufoData = ufoData;
            this.signalBus = signalBus;
        }

        void OnEnable()
        {
            signalBus.Subscribe<UfoDataUpdatedSignal>(UpdateView);

            UpdateView();
        }

        void OnDisable()
        {
            signalBus.Unsubscribe<UfoDataUpdatedSignal>(UpdateView);
        }

        protected abstract void UpdateView();
    }
}

