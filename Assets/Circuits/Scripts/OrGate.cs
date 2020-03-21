using UnityEngine;

namespace Circuits
{
    [AddComponentMenu("Circuits/Or Gate")]
    public class OrGate : MultiDependancyNode
    {
        protected override bool EvaluateState()
        {
            if (nodes == null)
                return true;

            foreach (CircuitNode node in nodes)
            {
                if (node?.Powered ?? false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
