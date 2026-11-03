public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = new SortedList<int, Tree>();

        foreach (var record in records)
        {
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };
            if ((t.Id == 0 && t.ParentId != 0) ||
                (t.Id != 0 && t.ParentId >= t.Id))
            {
                throw new ArgumentException();
            }
            ordered.Add(record.RecordId, t);
        }

        List<Tree> trees = ordered.Values.ToList();     
        if (trees.Count == 0)
        {
            throw new ArgumentException();
        }

        var previousRecordId = 0;
        foreach (Tree t in trees[1..])
        {
            if ((t.Id != 0 && t.Id != previousRecordId+1)) throw new ArgumentException();
            ++previousRecordId;
            trees[t.ParentId].Children.Add(t);
        }

        return trees[0];
    }
}