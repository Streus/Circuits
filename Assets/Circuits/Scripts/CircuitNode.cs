using UnityEngine;

namespace Circuits
{
    [ExecuteInEditMode, DisallowMultipleComponent]
    public abstract class CircuitNode : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private bool powered = true;

        [SerializeField]
        private bool inverted = false;

        private bool nextPowered;

        public bool Powered
        {
            get => inverted ^ powered;
            set => nextPowered = inverted ^ value;
        }

        public bool PoweredActual => powered;

        public bool Inverted => inverted;

        protected abstract bool EvaluateState();

        private void FixedUpdate()
        {
            nextPowered = EvaluateState();
        }

        private void LateUpdate()
        {
            powered = nextPowered;
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Powered ? Color.green : Color.gray;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
#endif
    }
}
