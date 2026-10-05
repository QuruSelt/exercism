public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) {
        return (IsNewYork: phoneNumber.Substring(0, 3) == "212",
         IsFake: phoneNumber.Substring(4, 3) == "555",
         LocalNumber: phoneNumber.Substring(8));
    }
    
    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) =>
        phoneNumberInfo.IsFake;
}
