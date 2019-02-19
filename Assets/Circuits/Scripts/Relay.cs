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
			if (node != null && node.IsPowered() != IsPowered())
			{
				if (delay <= 0f)
				{
					return inverted ? !node.IsPowered() : node.IsPowered();
				}
				else
				{
					StartCoroutine(DelayedPowerChange(node.IsPowered()));
				}
			}
			return IsPowered();
		}

		private IEnumerator DelayedPowerChange(bool value)
		{
			yield return new WaitForSeconds(delay);
			SetPowered(value);
		}
	}
}
