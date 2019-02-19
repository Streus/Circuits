using UnityEngine;

namespace Circuits
{
	public class AndGate : MultiDependancyNode
	{
		protected override bool EvaluateState()
		{
			if (nodes == null)
				return inverted ? true : false;

			for(int i = 0; i < nodes.Length; i++)
			{
				if(nodes[i] != null && !nodes[i].IsPowered())
				{
					return inverted ? true : false;
				}
			}
			return inverted ? false : true;
		}
	}
}
