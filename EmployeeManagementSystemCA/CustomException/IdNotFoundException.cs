using System;

namespace EmployeeManagementSystemCA.CustomException
{
    public class IdNotFoundException:Exception
    {
        public IdNotFoundException(string msg):base(msg)
        {
                
        }
    }
}
