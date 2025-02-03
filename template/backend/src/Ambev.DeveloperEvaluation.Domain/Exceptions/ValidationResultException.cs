using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Exceptions;

public class ValidationResultException(ValidationResultDetail validationResultDetail)
    : Exception("One or more validation errors occurred.")
{
    public IEnumerable<ValidationErrorDetail> Errors { get; } = validationResultDetail.Errors;
}