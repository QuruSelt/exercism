public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        int res = 0;
        switch (operation) {
            case "+":
                res = operand1 + operand2;
                break;
            case "*":
                res = operand1 * operand2;
                break;
            case "/":
                if (operand2 == 0) return "Division by zero is not allowed.";
                res = operand1 / operand2;
                break;
            case "":
                throw new ArgumentException();
            case null:
                throw new ArgumentNullException();
            default:
                throw new ArgumentOutOfRangeException();
        }
        return $"{operand1} {operation} {operand2} = {res}";
    }
}
