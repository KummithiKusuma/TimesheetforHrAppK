namespace TimeSheetHrEmployeeApp.Exceptions
{
    public class NoLeaveRequestAvailableException : Exception
    {

        string message;
        public NoLeaveRequestAvailableException()
        {
            message = "No such Leave found";
        }
        public override string Message => message;
    }
}

