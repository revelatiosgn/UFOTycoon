using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace UFOT.Human
{
    public class HumanReturnState : HumanMoveState
    {
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
            if (GetRandomSpawnPosition(out Vector3 position))
                MoveToPosition(position);
            else
                fsm.MakeTransition<HumanIdleState>();
        }

        public override void OnUpdate(float dt)
        {
            NavMeshAgent agent = fsm.NavMeshAgent;

            // Hack to prevent stuck with other agents
            if ((agent.transform.position - agent.destination).sqrMagnitude < 10f)
                agent.radius = 0.001f;

            if (IsStopped())
            {
                humanPool.Push(humanActor);
            }
        }

        bool GetRandomSpawnPosition(out Vector3 result)
        {
            result = Vector3.zero;

            HumanSpawn spawn = humanSpawner.GetRandomSpawn();
            if (spawn == null)
                return false;

            result = spawn.transform.position;

            return true;
        }
    }
}

