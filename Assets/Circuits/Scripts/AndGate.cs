namespace Circuits
{
    public class AndGate : MultiDependancyNode
    {
        protected override bool EvaluateState()
        {
            if (nodes == null)
                return false;

            foreach (CircuitNode node in nodes)
            {
                if (node?.Powered ?? false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
