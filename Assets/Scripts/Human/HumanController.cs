using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

using UFOT.Data;
using UFOT.UI;

namespace UFOT.Human
{
    /// <summary>
    /// Human movement controller
    /// </summary>
    public class HumanController : MonoBehaviour
    {
        [SerializeField] HumanConfig humanConfig;
        public HumanConfig HumanConfig { get => humanConfig; }

        [SerializeField] CaptureProgress captureProgress;
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] Animator animator;

        static readonly int walkId = Animator.StringToHash("Walk");
        static readonly int runId = Animator.StringToHash("Run");
        static readonly int idleId = Animator.StringToHash("Idle");
        const float agentRadius = 0.17f;

        void OnEnable()
        {
            SetCaptureProgress(0f);
        }

        public void SetCaptureProgress(float progress)
        {
            captureProgress.SetProgress(progress);
            captureProgress.gameObject.SetActive(progress > 0f);
        }

        public void MoveToPosition(Vector3 position, bool isRunning = false)
        {
            navMeshAgent.speed = isRunning ? humanConfig.runSpeed : humanConfig.walkSpeed;
            navMeshAgent.destination = position;
            navMeshAgent.isStopped = false;
            animator.CrossFade(isRunning ? runId : walkId, 0.2f);
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
            animator.CrossFade(idleId, 0.2f);
        }

        public bool IsStopped()
        {
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Warp(Vector3 position)
        {
            navMeshAgent.Warp(position);
        }

        public void SetAgentRadius(float radius = agentRadius)
        {
            navMeshAgent.radius = radius;
        }

        public class Factory : PlaceholderFactory<GameObject, Transform, HumanController>
        {     
        }
    }
}

