using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> stack = new Stack<char>();

        try {
            foreach (char c in input) {
                switch (c) {
                    case '(':
                        stack.Push(')');
                        break;
                    case ')':
                        if (stack.Pop() != c) return false;
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case ']':
                        if (stack.Pop() != c) return false;
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '}':
                        if (stack.Pop() != c) return false;
                        break;
                    default:
                        break;
                }
            }
        } catch (InvalidOperationException e) {
            return false;
        }

        try {
            stack.Pop();
        } catch (InvalidOperationException e) {
            return true;
        }
        return false;
    }
}
