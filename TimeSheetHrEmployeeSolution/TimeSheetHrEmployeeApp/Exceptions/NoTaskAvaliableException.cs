namespace TimeSheetHrEmployeeApp.Exceptions
{
    public class NoTaskAvaliableException : Exception
    {
        string message;
        public NoTaskAvaliableException()
        {
            message = "No such Task found";
        }
        public override string Message => message;
    }
}
