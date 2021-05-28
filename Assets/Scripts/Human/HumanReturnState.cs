using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace UFOT.Human
{
    public class HumanReturnState : HumanState
    {
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] HumanActor humanActor;

        HumanPool humanPool;
        HumanSpawner humanSpawner;

        [Inject]
        void Construct(HumanPool humanPool, HumanSpawner humanSpawner)
        {
            this.humanPool = humanPool;
            this.humanSpawner = humanSpawner;
        }

        public override void OnEnter()
        {
            HumanSpawn spawn = humanSpawner.GetRandomSpawn();
            if (spawn == null)
            {
                fsm.MakeTransition<HumanIdleState>();
                return;
            }

            navMeshAgent.destination = spawn.transform.position;
        }

        public override void OnUpdate(float dt)
        {
            // Hack to prevent stuck with other agents
            if ((navMeshAgent.transform.position - navMeshAgent.destination).sqrMagnitude < 10f)
                navMeshAgent.radius = 0.001f;

            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        fsm.MakeTransition<HumanIdleState>();
                        humanPool.Push(humanActor);
                    }
                }
            }
        }
    }
}

