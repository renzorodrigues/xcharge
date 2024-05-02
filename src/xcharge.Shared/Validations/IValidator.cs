namespace xcharge.Shared.Validations;

public interface IValidator
{
    void Failure(string errorMessage);
    void ThrowException();
    void CheckError();
}
