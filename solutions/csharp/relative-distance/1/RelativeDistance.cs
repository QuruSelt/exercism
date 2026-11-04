public class RelativeDistance
{
    private class FamilyGraph {
        public record Link(int src, int dst);
        public record Node(int id, string name);

        private Node[] _nodes; 
        private HashSet<Link> _links; 
        
        public FamilyGraph(Dictionary<string, int> register) {
            _nodes = new Node[register.Count];
            _links = new HashSet<Link>();
            foreach (var (name, id) in register) {
                _nodes[id] = new Node(id, name);
            }
        }

        public Node? GetNode(int id) {
            foreach (Node node in _nodes) if (node.id == id) return node;
            return null;
        }
        public Node? GetNode(string name) {
            foreach (Node node in _nodes) if (node.name == name) return node;
            return null;
        }

        public void AddLink(int src, int dst) {
            _links.Add(new Link(src, dst));
            _links.Add(new Link(dst, src));
        }

        public int GetDistance(int src, int dst) {
            var seen = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(_nodes[src].id);
            seen.Add(_nodes[src].id);
            queue.Enqueue(-1);

            int dist = 1;  
            int currNodeId = -1;
            while (queue.TryDequeue(out currNodeId)) {
                if (currNodeId == -1) {
                    if (queue.TryPeek(out currNodeId)) queue.Enqueue(-1);
                    dist++;
                    continue;
                }
                foreach (Link link in _links) {
                    if (link.src == currNodeId) {
                        if (link.dst == dst) return dist;
                        if (!seen.Contains(link.dst)) {
                            queue.Enqueue(link.dst);
                            seen.Add(link.dst);
                        }
                    }
                }
            }
            return -1;
        }
    }

    private FamilyGraph _graph;
    private Dictionary<string, int> _register;

    public RelativeDistance(Dictionary<string, string[]> familyTree)
    {
        _register = new Dictionary<string, int>();
        int n = 0;
        foreach (var (parent, children) in familyTree) {
            if (!_register.ContainsKey(parent)) _register.Add(parent, n++);
            foreach (string child in children) {
                if (!_register.ContainsKey(child)) _register.Add(child, n++);
            }
        }

        _graph = new FamilyGraph(_register);
        foreach (var (parent, children) in familyTree) {
            for (int i = 0; i < children.Length - 1; i++) {
                _graph.AddLink(_register[parent], _register[children[i]]);
                for (int k = i + 1; k < children.Length; k++) {
                    _graph.AddLink(_register[children[i]], _register[children[k]]);
                }
            }
            _graph.AddLink(_register[parent], _register[children[^1]]);
        }
    }

    public int DegreeOfSeparation(string personA, string personB) {
        return _graph.GetDistance(_register[personA], _register[personB]);
    }
}
