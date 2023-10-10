

namespace Proyecto.Data.Common
{
    public enum Result
    {
        Success = 1,
        Error,
        NoRecords,
        ExpiredCode,
        UserNoExists,
        InvalidSession,
        InvalidPermissionRole
    }
}
