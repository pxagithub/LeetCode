using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _1600._皇位继承顺序
{
    class Program
    {
        static void Main(string[] args)
        {
            ThroneInheritance t = new ThroneInheritance("king"); // 继承顺序：king
            t.Birth("king", "andy"); // 继承顺序：king > andy
            t.Birth("king", "bob"); // 继承顺序：king > andy > bob
            t.Birth("king", "catherine"); // 继承顺序：king > andy > bob > catherine
            t.Birth("andy", "matthew"); // 继承顺序：king > andy > matthew > bob > catherine
            t.Birth("bob", "alex"); // 继承顺序：king > andy > matthew > bob > alex > catherine
            t.Birth("bob", "asha"); // 继承顺序：king > andy > matthew > bob > alex > asha > catherine
            Console.WriteLine(string.Join(",",t.GetInheritanceOrder())); // 返回 ["king", "andy", "matthew", "bob", "alex", "asha", "catherine"]
            t.Death("bob"); // 继承顺序：king > andy > matthew > bob（已经去世）> alex > asha > catherine
            Console.WriteLine(string.Join(",", t.GetInheritanceOrder()));

        }
    }

    public class ThroneInheritance
    {
        private readonly string _kingName;
        private ISet<string> dead;
        private Dictionary<string, IList<string>> edges;
        public ThroneInheritance(string kingName)
        {
            _kingName = kingName;
            dead = new HashSet<string>();
            edges = new Dictionary<string, IList<string>>();
        }

        public void Birth(string parentName, string childName)
        {
            IList<string> children;
            if (edges.TryGetValue(parentName,out children))
            {
                children.Add(childName);
                edges[parentName] = children;
            }
            else
            {
                children = new List<string>();
                children.Add(childName);
                edges.Add(parentName, children);
            }

        }

        public void Death(string name)
        {
            dead.Add(name);
        }

        public IList<string> GetInheritanceOrder()
        {
            IList<string> ans = new List<string>();
            PreOrder(ans, _kingName);
            return ans;
        }

        public void PreOrder(IList<string> ans, string name)
        {
            if (!dead.Contains(name))
            {
                ans.Add(name);
            }

            IList<string> children = edges.TryGetValue(name, out children) ? children : new List<string>();
            foreach (var child in children)
            {
                PreOrder(ans, child);
            }
        }
    }

    /**
     * Your ThroneInheritance object will be instantiated and called as such:
     * ThroneInheritance obj = new ThroneInheritance(kingName);
     * obj.Birth(parentName,childName);
     * obj.Death(name);
     * IList<string> param_3 = obj.GetInheritanceOrder();
     */
}
