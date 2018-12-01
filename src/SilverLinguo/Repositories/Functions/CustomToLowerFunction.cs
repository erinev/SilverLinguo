using System.Data.SQLite;

namespace SilverLinguo.Repositories.Functions
{
    [SQLiteFunction(Name = "CUSTOM_TO_LOWER", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class CustomToLowerFunction: SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return args[0].ToString().ToLowerInvariant();
        }
    }
}