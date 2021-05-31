using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace UFOT.Human
{
    /// <summary>
    /// Human State when moving to building
    /// </summary>
    public class HumanReturnState : HumanState
    {
        [SerializeField] HumanController humanController;

        HumanPool humanPool;
        HumanRoot humanRoot;

        [Inject]
        void Construct(HumanRoot humanRoot, HumanPool humanPool)
        {
            this.humanPool = humanPool;
            this.humanRoot = humanRoot;
        }

        public override void OnEnter()
        {
            fsm.HumanController.SetAgentRadius(0.001f);
            if (GetReturnPosition(out Vector3 position))
                fsm.HumanController.MoveToPosition(position, true);
            else
                fsm.MakeTransition<HumanIdleState>();
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.HumanController.IsStopped())
                humanPool.Push(fsm.HumanController);
        }

        bool GetReturnPosition(out Vector3 position)
        {
            position = Vector3.zero;
            if (humanRoot.Spawns.Count == 0)
                return false;

            HumanSpawn rndSpawn = humanRoot.Spawns[Random.Range(0, humanRoot.Spawns.Count)];
            position = rndSpawn.transform.position;

            return true;
        }
    }
}

