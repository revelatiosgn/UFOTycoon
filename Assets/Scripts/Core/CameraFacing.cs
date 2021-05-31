using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFOT.Core
{
    /// <summary>
    /// Turns self transform to main camera forward every LateUpdate
    /// </summary>
    public class CameraFacing : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}

