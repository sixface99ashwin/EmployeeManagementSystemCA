using System;

namespace EmployeeManagementSystemCA.CustomException
{
    public class DatabaseException:Exception
    {
        public DatabaseException(string msg):base(msg)
        {

        }
    }
}
