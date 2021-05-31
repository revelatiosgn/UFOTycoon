using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Core;
using UnityEngine.AI;

namespace UFOT.Human
{
    /// <summary>
    /// Controls human behaviour
    /// </summary>
    public class HumanFSM : BaseFSM<HumanState>
    {
        [SerializeField] HumanController humanController;

        public HumanController HumanController { get => humanController; }

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

