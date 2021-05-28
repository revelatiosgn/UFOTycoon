using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UFOT.Human
{
    public class HumanWalkState : HumanState
    {
        [SerializeField] float walkRadius = 5f;
        [SerializeField] NavMeshAgent navMeshAgent;

        public override void OnEnter()
        {
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            Vector3 finalPosition = hit.position;
            navMeshAgent.destination = finalPosition;
        }

        public override void OnUpdate(float dt)
        {
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        fsm.MakeTransition<HumanIdleState>();
                    }
                }
            }
        }
    }
}

