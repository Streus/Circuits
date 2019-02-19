using UnityEngine;

namespace Circuits
{
	public abstract class SingleDependancyNode : CircuitNode
	{
		[SerializeField]
		protected CircuitNode node = null;

#if UNITY_EDITOR
		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (node != null)
			{
				Gizmos.color = Color.white;
				Vector3 dir = transform.position - node.transform.position;
				Gizmos.DrawLine(transform.position, dir.normalized + node.transform.position);
			}
		}
#endif
	}
}
