using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UFOT.Human
{
    /// <summary>
    /// Human State when moving to random position
    /// </summary>
    public class HumanWalkState : HumanState
    {
        [SerializeField] float walkRadius = 5f;

        public override void OnEnter()
        {
            fsm.HumanController.SetAgentRadius();
            fsm.HumanController.MoveToPosition(GetRandomDestination());
        }

        public override void OnUpdate(float dt)
        {   
            if (fsm.HumanController.IsStopped())
                fsm.MakeTransition<HumanIdleState>();
        }

        Vector3 GetRandomDestination()
        {
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);

            return hit.position;
        }
    }
}

