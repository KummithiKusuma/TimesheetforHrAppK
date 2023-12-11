namespace TimeSheetHrEmployeeApp.Exceptions
{
    public class NoApprovalFoundException : Exception
    {
        string message;
        public NoApprovalFoundException()

        {
            message = "No such Approval found";
        }
        public override string Message => message;
    }
}
