using UnityEngine;

namespace Circuits
{
	public abstract class MultiDependancyNode : CircuitNode
	{
		[SerializeField]
		protected CircuitNode[] nodes = new CircuitNode[1];

#if UNITY_EDITOR
		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (nodes != null)
			{
				Gizmos.color = Color.white;
				for (int i = 0; i < nodes.Length; i++)
				{
					if (nodes[i] != null)
					{
						Vector3 dir = transform.position - nodes[i].transform.position;
						Gizmos.DrawLine(transform.position, dir.normalized + nodes[i].transform.position);
					}
				}
			}
		}
#endif
	}
}
