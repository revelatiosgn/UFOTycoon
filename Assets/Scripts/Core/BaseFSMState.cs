using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFOT.Core
{
    public abstract class BaseFSMState : MonoBehaviour
    {
        public virtual void OnEnter() {}
        public virtual void OnExit() {}
        public virtual void OnUpdate(float dt) {}
    }
}