using UnityEngine;

namespace Circuits
{
	public class Source : CircuitNode
	{
		protected override bool EvaluateState()
		{
			return !inverted;
		}
	}
}
