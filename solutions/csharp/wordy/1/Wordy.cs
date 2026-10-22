public enum Operator {
    None,
    Addition,
    Substraction,
    Multiplication,
    Division
}

public static class Wordy
{
    public static int Answer(string question)
    {
        if (question.Length < 10) throw new ArgumentException();
        if (question.Substring(0, 8) != "What is ") throw new ArgumentException();

        int res = 0;
        string operation = question.Substring(8)[..^1];
        bool matchingNum = true;
        int n = 0;
        Operator op = Operator.None;

        foreach (string element in operation.Split(' ')) {
            switch (element) {
                case "plus":
                    if (matchingNum) throw new ArgumentException();
                    op = Operator.Addition;
                    matchingNum = true;
                    break;
                case "minus":
                    if (matchingNum) throw new ArgumentException();
                    op = Operator.Substraction;
                    matchingNum = true;
                    break;
                case "multiplied":
                    if (matchingNum) throw new ArgumentException();
                    op = Operator.Multiplication;
                    break;
                case "divided":
                    if (matchingNum) throw new ArgumentException();
                    op = Operator.Division;
                    break;
                case "by":
                    if (matchingNum) throw new ArgumentException();
                    if (op != Operator.Division && op != Operator.Multiplication) throw new ArgumentException();
                    matchingNum = true;
                    break;
                default:
                    if (!matchingNum || !Int32.TryParse(element, out n)) throw new ArgumentException();
                    res = op switch {
                        Operator.Addition => res + n,
                        Operator.Substraction => res - n,
                        Operator.Multiplication => res * n,
                        Operator.Division => res / n,
                        _ => res = n
                    };
                    matchingNum = false;
                    n = 0;
                    break;
            }
        }

        if (matchingNum) throw new ArgumentException();
        return res + n;
    }
}