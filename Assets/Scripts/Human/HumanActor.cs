using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UFOT.Data;

namespace UFOT.Human
{
    public class HumanActor : MonoBehaviour
    {
        [SerializeField] HumanConfig humanConfig;
        public HumanConfig HumanConfig { get => humanConfig; }
    }
}

