using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UFOT.Human
{
    public class HumanIdleState : HumanState
    {
        [SerializeField] float minWaitTime = 1f;
        [SerializeField] float maxWaitTime = 3f;
        [SerializeField] float chanceToWalk = 5f;
        [SerializeField] float chanceToReturn = 1f;

        float stateTime = 0f;
        float waitTime = 0f;
        static readonly int idleId = Animator.StringToHash("Idle");

        public override void OnEnter()
        {
            stateTime = 0f;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            fsm.Animator.CrossFade(idleId, 0.2f);
            fsm.NavMeshAgent.isStopped = false;
        }

        public override void OnUpdate(float dt)
        {
            stateTime += dt;
            if (stateTime > waitTime)
            {
                if (Random.Range(0f, chanceToWalk + chanceToReturn) < chanceToWalk)
                    fsm.MakeTransition<HumanWalkState>();
                else
                    fsm.MakeTransition<HumanReturnState>();
            }
        }
    }
}

