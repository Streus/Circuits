namespace Circuits
{
    public class XorGate : MultiDependancyNode
    {
        protected override bool EvaluateState()
        {
            if (nodes == null)
                return true;

            bool found = false;
            foreach (CircuitNode node in nodes)
            {
                if (node?.Powered ?? false)
                {
                    if (found)
                    {
                        return false;
                    }
                    found = true;
                }
            }
            return found;
        }
    }
}
