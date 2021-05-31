using UnityEngine;
using Zenject;
using UFOT.Signals;
using UFOT.UFO;

namespace UFOT.UI
{
    /// <summary>
    /// UI element represents landing pad direction
    /// </summary>
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

            Vector2 screenBase = WorldToScreenPointProjected(Camera.main, ufoBase.position);
            Vector2 screenUFO = WorldToScreenPointProjected(Camera.main, ufoController.transform.position);;

            Vector2 direction = screenBase - screenUFO;
            if (direction != Vector2.zero)
            {
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }

        Vector2 WorldToScreenPointProjected(Camera camera, Vector3 worldPos)
        {
            Vector3 camNormal = camera.transform.forward;
            Vector3 vectorFromCam = worldPos - camera.transform.position;
            float camNormDot = Vector3.Dot(camNormal, vectorFromCam);
            if (camNormDot <= 0)
            {
                // we are behind the camera forward facing plane, project the position in front of the plane
                Vector3 proj = (camNormal * camNormDot * 1.01f);
                worldPos = camera.transform.position + (vectorFromCam - proj);
            }

            return RectTransformUtility.WorldToScreenPoint(camera, worldPos);
        }
    }
}

