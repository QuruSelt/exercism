[Flags]
enum Permission : byte
{
    None = 0b00000000,
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = 0b00000111
}

[Flags]
enum AccountType : byte
{
    Guest = 0b00000001,
    User = 0b00000011,
    Moderator = 0b00000111
}

static class Permissions
{
    public static Permission Default(AccountType accountType) {
        if ((accountType & AccountType.Moderator) == accountType) return (Permission) ((byte) accountType);
        return Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => (Permission) (current - (current & revoke));

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
