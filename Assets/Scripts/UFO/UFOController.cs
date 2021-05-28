using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;

namespace UFOT.UFO
{
    public class UFOController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick;

        Rigidbody rb;
        UFOData ufoData;

        [Inject]
        void Construct(UFOData ufoData)
        {
            this.ufoData = ufoData;
        }

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Vector3 input = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            rb.velocity = input * ufoData.UFOConfig.Speed.Value * 0.1f;
        }
    }
}

