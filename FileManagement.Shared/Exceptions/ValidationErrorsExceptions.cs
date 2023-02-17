namespace FileManagement.Shared.Exceptions
{
    public class ValidationErrorsExceptions : BaseException
    {
        public List<string> ErrorsMesssages { get; set; }

        public ValidationErrorsExceptions(List<string> errorsMesssages) : base(string.Empty)
        {
            ErrorsMesssages = errorsMesssages;
        }

        public ValidationErrorsExceptions(string errorsMesssages) : base(string.Empty)
        {
            ErrorsMesssages = new List<string> { errorsMesssages };
        }
    }
}
