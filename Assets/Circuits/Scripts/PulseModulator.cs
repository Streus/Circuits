using System.Collections;
using UnityEngine;

namespace Circuits
{
    [AddComponentMenu("Circuits/Pulse Modulator")]
    public class PulseModulator : SingleDependancyNode
    {
        private bool isDirty = false;
        private Coroutine coroutine = null;
        private void Start()
        {
            if (node != null)
            {
                node.onPoweredChange += (bool state) => {
                    if (state)
                    {
                        isDirty = true;
                        StopAllCoroutines();
                        coroutine = null;
                    }
                };
            }
        }

        protected override bool EvaluateState()
        {
            if (isDirty)
            {
                coroutine = StartCoroutine(ResetState());
                isDirty = false;
            }

            return coroutine != null;
        }

        private IEnumerator ResetState()
        {
            yield return new WaitForFixedUpdate();
            Powered = false;
            coroutine = null;
        }
    }
}
