using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UFOT.Human
{
    public class HumanWalkState : HumanMoveState
    {
        [SerializeField] float walkRadius = 5f;

        public override void OnEnter()
        {
            MoveToPosition(GetRandomDestination());
        }

        public override void OnUpdate(float dt)
        {   
            if (IsStopped())
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

