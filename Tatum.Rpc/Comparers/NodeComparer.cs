using System.Collections.Generic;
using Tatum.Rpc.Models;

namespace Tatum.Rpc.Comparers
{
    internal class NodeComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            int blockCountComparison = x.BlockCount.CompareTo(y.BlockCount);
            if (blockCountComparison != 0)
            {
                return blockCountComparison;
            }
            else
            {
                return x.ResponseTime.CompareTo(y.ResponseTime);
            }
        }
    }
}