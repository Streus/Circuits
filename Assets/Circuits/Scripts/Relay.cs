using System.Collections;
using UnityEngine;

namespace Circuits
{
    public class Relay : SingleDependancyNode
    {
        [SerializeField]
        private float delay = 0f;

        public bool HasNode()
        {
            return node != null;
        }

        protected override bool EvaluateState()
        {
            if (node?.Powered != Powered)
            {
                if (delay <= 0f)
                {
                    return Inverted ^ node.Powered;
                }
                else
                {
                    StartCoroutine(DelayedPowerChange(Inverted ^ node.Powered));
                }
            }
            return Powered;
        }

        private IEnumerator DelayedPowerChange(bool value)
        {
            yield return new WaitForSeconds(delay);
            Powered = value;
        }
    }
}
