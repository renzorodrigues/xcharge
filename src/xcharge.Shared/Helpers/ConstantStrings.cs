namespace xcharge.Shared.Helpers;

public static class ConstantStrings
{
    public static class Headers
    {
        public const string ApplicationJson = "application/json";
    }

    public static class Validation
    {
        public const string InvalidRequest = "Request is null.";
        public const string InvalidCnpj = "Cnpj is not valid.";
    }

    public static class Response
    {
        public const string RequestSuccessfully = "The request was successfully.";
        public const string CreatedSuccessfully = "It was created successfully.";
        public const string UpdatedSuccessfully = "It was updated successfully.";
        public const string RequestFailed = "The request failed.";
        public const string ObjectNotFound = "Object not found.";
        public const string CondominiumNotFound = "Condominium not found.";
        public const string NoRecordsToBeRetrieved = "No records to be retrieved.";
        public const string InvalidCnpj = "Cnpj is not valid.";
    }
}
