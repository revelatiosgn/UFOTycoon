using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Core;

namespace UFOT.Human
{
    public class HumanFSM : BaseFSM<HumanState>
    {
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

