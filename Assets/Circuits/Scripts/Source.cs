using UnityEngine;

namespace Circuits
{
    [AddComponentMenu("Circuits/Source")]
    public class Source : CircuitNode
    {
        protected override bool EvaluateState() => true;
    }
}
