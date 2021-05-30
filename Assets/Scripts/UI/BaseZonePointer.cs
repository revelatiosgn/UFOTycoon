using UnityEngine;
using Zenject;
using UFOT.Signals;
using UFOT.UFO;

namespace UFOT.UI
{
    public class BaseZonePointer : MonoBehaviour
    {
        [SerializeField] GameObject pointer;
        [SerializeField] UFOController ufoController;
        [SerializeField] Transform ufoBase;

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

        void Update()
        {
            RotateToBase();
        }

        void OnBaseEnter()
        {
            pointer.SetActive(false);
        }

        void OnBaseExit()
        {
            pointer.SetActive(true);
        }

        void RotateToBase()
        {
            if (ufoController == null || ufoBase == null)
                return;

            Vector3 screenBase = Camera.main.WorldToScreenPoint(ufoBase.position);
            Vector3 screenUFO = Camera.main.WorldToScreenPoint(ufoController.transform.position);
            Vector3 direction = screenBase - screenUFO;
            if (direction != Vector3.zero)
            {
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}

