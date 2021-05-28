using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Core;

namespace UFOT.Human
{
    public abstract class HumanState : BaseFSMState
    {
        protected HumanFSM fsm;

        void Awake()
        {
            fsm = GetComponent<HumanFSM>();
        }
    }
}

