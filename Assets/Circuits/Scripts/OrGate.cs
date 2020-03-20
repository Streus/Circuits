namespace Circuits
{
    public class OrGate : MultiDependancyNode
    {
        protected override bool EvaluateState()
        {
            if (nodes == null)
                return true;

            foreach (CircuitNode node in nodes)
            {
                if (node?.Powered ?? false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
