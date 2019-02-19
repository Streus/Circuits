using UnityEngine;

namespace Circuits
{
	[ExecuteInEditMode, DisallowMultipleComponent]
	public abstract class CircuitNode : MonoBehaviour
	{
		public bool Activated { get { return activated; } private set { activated = value; } }
		[SerializeField]
		private bool activated = true;

		private bool nextActivatedValue;

		protected abstract bool EvalState();

		private void Update()
		{
			nextActivatedValue = EvalState();
		}

		private void LateUpdate()
		{
			Activated = nextActivatedValue;
		}

#if UNITY_EDITOR
		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Activated ? Color.green : Color.gray;
			Gizmos.DrawWireSphere(transform.position, 1f);
		}
#endif
	}
}
