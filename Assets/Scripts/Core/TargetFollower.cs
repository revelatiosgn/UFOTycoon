using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFOT.Core
{
    /// <summary>
    /// Smooth update self position to target position
    /// </summary>
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3 offset;
        [SerializeField] float delay = 10f;

        Vector3 currentVel = Vector3.zero;

        void Start()
        {
            if (target == null)
                return;

            transform.position = target.position + offset;
            transform.LookAt(target);
        }

        void LateUpdate()
        {
            if (target == null)
                return;

            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVel, Time.fixedDeltaTime * delay);
        }
    }
}
