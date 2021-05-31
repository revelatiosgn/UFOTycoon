using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UFOT.Human
{
    /// <summary>
    /// Human State when Idle
    /// </summary>
    public class HumanIdleState : HumanState
    {
        float stateTime = 0f;
        float waitTime = 0f;
        static readonly int idleId = Animator.StringToHash("Idle");

        public override void OnEnter()
        {
            stateTime = 0f;
            fsm.HumanController.Stop();
            fsm.HumanController.SetAgentRadius();
        }

        public override void OnUpdate(float dt)
        {
            stateTime += dt;
            if (stateTime > fsm.HumanController.HumanConfig.idleTime)
            {
                float rnd = Random.Range(0f, fsm.HumanController.HumanConfig.walkChance + fsm.HumanController.HumanConfig.returnChance);
                if (rnd < fsm.HumanController.HumanConfig.walkChance)
                    fsm.MakeTransition<HumanWalkState>();
                else
                    fsm.MakeTransition<HumanReturnState>();
            }
        }
    }
}

