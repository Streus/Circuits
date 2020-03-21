using UnityEngine;

namespace Circuits
{
    [DisallowMultipleComponent]
    public abstract class CircuitNode : MonoBehaviour
    {
        public delegate void StateCallback(bool state);

        [SerializeField, ReadOnlyInPlayMode]
        private bool powered = true;

        [SerializeField]
        private bool inverted = false;

        private bool nextPowered;
        public event StateCallback onPoweredChange;

        public bool Powered
        {
            get => inverted ^ powered;
            set => nextPowered = value;
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
            if (powered != nextPowered)
            {
                powered = nextPowered;
                onPoweredChange?.Invoke(Powered);
            }
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
