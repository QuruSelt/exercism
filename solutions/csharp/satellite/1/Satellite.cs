public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length != inOrder.Length
           || !Array.TrueForAll(preOrder, e => inOrder.Contains(e))
           || preOrder.Length != new HashSet<char>(preOrder).Count)
            throw new ArgumentException();
        
        if (preOrder.Length == 0) return null;

        if (preOrder.Length == 1) return new Tree(preOrder[0], null, null);
        
        int idPreRoot = 0;
        int idInRoot = Array.FindIndex(inOrder, e => e == preOrder[idPreRoot]);
        
        char[] leftPreOrder = preOrder[(idPreRoot+1)..(idInRoot+1)];
        char[] leftInOrder = inOrder[(idPreRoot)..(idInRoot)];
        char[] rightPreOrder = preOrder[(idInRoot+1)..];
        char[] rightInOrder = inOrder[(idInRoot+1)..];

        return new Tree(preOrder[idPreRoot],
                        TreeFromTraversals(leftPreOrder, leftInOrder),
                        TreeFromTraversals(rightPreOrder, rightInOrder));
    }
}
