using FluentValidation;
using RideSharing.Abstractions.Exceptions;

namespace RideSharing.Abstractions.Extensions
{
    public static class EntityValidator
    {

        public static TEntity Validate<TEntity, TValidator>(this TEntity entity)
            where TValidator : AbstractValidator<TEntity>, new()

        {
            var validator = new TValidator();

            var validationResult = validator.Validate(entity);

            if (validationResult.IsValid) return entity;

            var exception = new NotValidException($" {nameof(TEntity)} is not valid");

            validationResult.Errors.ForEach(error => exception.Errors.Add(error.ErrorMessage));

            throw exception;
        }



    }
}
