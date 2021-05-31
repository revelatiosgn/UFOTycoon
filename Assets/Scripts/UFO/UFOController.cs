using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using UFOT.Data;
using UFOT.Map;

namespace UFOT.UFO
{
    /// <summary>
    /// Controls Player movement
    /// </summary>
    public class UFOController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick;
        [SerializeField] MapBorder mapBorder;

        Rigidbody rb;
        UFOData ufoData;
        Vector3 currentVelocity = Vector3.zero;

        [Inject]
        void Construct(UFOData ufoData)
        {
            this.ufoData = ufoData;
        }

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            HandleInput();
            HandleBorders();
        }

        void HandleInput()
        {
            Vector3 input = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            rb.velocity = input * ufoData.UFOConfig.speed.Value * ufoData.UFOConfig.speedMultiplier;

            if (rb.velocity != Vector3.zero)
                rb.MoveRotation(Quaternion.LookRotation(rb.velocity, Vector3.up));
        }

        void HandleBorders()
        {
            if (mapBorder == null)
                return;

            Vector3 clampedVelocity = rb.velocity;

            if (rb.position.x <= mapBorder.Left && rb.velocity.x < 0f)
                clampedVelocity.x = 0f;
            else if (rb.position.x >= mapBorder.Right && rb.velocity.x > 0f)
                clampedVelocity.x = 0f;

            if (rb.position.z <= mapBorder.Bottom && rb.velocity.z < 0f)
                clampedVelocity.z = 0f;
            else if (rb.position.z >= mapBorder.Top && rb.velocity.z > 0f)
                clampedVelocity.z = 0f;

            rb.velocity = clampedVelocity;
        }
    }
}

