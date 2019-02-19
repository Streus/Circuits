using UnityEngine;

namespace Circuits
{
	public class XorGate : MultiDependancyNode
	{
		protected override bool EvaluateState()
		{
			if (nodes == null)
				return inverted ? false : true;

			bool found = false;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i] != null && nodes[i].IsPowered())
				{
					if(found)
					{
						return inverted ? true : false;
					}
					found = true;
				}
			}
			return inverted ? !found : found;
		}
	}
}
