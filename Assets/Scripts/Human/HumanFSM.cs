using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Core;
using UnityEngine.AI;

namespace UFOT.Human
{
    public class HumanFSM : BaseFSM<HumanState>
    {
        [SerializeField] HumanActor humanActor;
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] Animator animator;

        public HumanActor HumanActor { get => humanActor; }
        public NavMeshAgent NavMeshAgent { get => navMeshAgent; }
        public Animator Animator { get => animator; }

        void OnEnable()
        {
            MakeTransition<HumanWalkState>();
        }

        void Update()
        {
            UpdateStates(Time.deltaTime);
        }
    }
}

