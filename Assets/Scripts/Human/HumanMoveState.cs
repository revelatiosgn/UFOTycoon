using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UFOT.Human
{
    public abstract class HumanMoveState : HumanState
    {
        protected static readonly int walkId = Animator.StringToHash("Walk");
        protected static readonly int runId = Animator.StringToHash("Run");

        protected void MoveToPosition(Vector3 position)
        {
            bool isRunning = Random.Range(0, 2) == 0;

            fsm.NavMeshAgent.speed = isRunning ? fsm.HumanActor.HumanConfig.walkSpeed : fsm.HumanActor.HumanConfig.runSpeed;
            fsm.NavMeshAgent.destination = position;
            fsm.NavMeshAgent.isStopped = false;
            fsm.Animator.CrossFade(isRunning ? walkId : runId, 0.2f);
        }

        protected bool IsStopped()
        {   
            NavMeshAgent agent = fsm.NavMeshAgent;
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

