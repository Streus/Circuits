using UnityEngine;

namespace Circuits
{
	public class Relay : CircuitNode
	{
		[SerializeField]
		private CircuitNode node;

		protected override bool EvalState()
		{
			if (node != null)
				return node.Activated;
			else
				return Activated;
		}
	}
}
