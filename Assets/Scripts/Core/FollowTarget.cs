using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFOT.Core
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float delay = 10f;

        Vector3 currentVel = Vector3.zero;

        void Update()
        {
            if (target == null)
                return;

            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVel, Time.fixedDeltaTime * delay);
        }
    }
}
