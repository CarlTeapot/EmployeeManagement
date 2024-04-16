namespace EmployeeManagement.Exceptions;

public class EmployeeRegisteredException : Exception
    {
        public EmployeeRegisteredException(string message) : base(message)
        {
        }

        public EmployeeRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
