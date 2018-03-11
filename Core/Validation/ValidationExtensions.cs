using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Validation
{
    public static class ValidationExtensions
    {
        public static Tuple<bool,string> Validate<T>(this T entity) where T : BaseEntity
        {
            var entityName = entity.GetType().Name;

            var type = Type.GetType(entityName + "Validator");
            if (type == null)
            {
                return ValidatorUndefined(entityName);
            }
            var entityValidator = Activator.CreateInstance(type);
            var validateMethod = type.GetMethod("Validate");

            var result = validateMethod?.Invoke(entityValidator, new object[] { entity });
            if (result == null)
            {
                return ValidatorUndefined(entityName);
            }
            var isValidProperty = type.GetProperty("IsValid");
            var isValid = (bool)isValidProperty.GetValue(entityValidator, null);
            if (!isValid)
            {
                return ErrorResult(entityValidator, type);
            }
            return ValidationSucceeded();
        }

        public static Tuple<bool, string> Validate<T>(T entity, AbstractValidator<T> validator)
        {
            var validationResult = validator.Validate(entity);
            if (validationResult.IsValid)
            {
                var firstErrorMessage = validationResult.Errors.FirstOrDefault();
                return ErrorResult(firstErrorMessage?.ErrorMessage);
            }
            return ValidationSucceeded();
        }

        private static Tuple<bool, string> ValidationSucceeded()
        {
            return new Tuple<bool, string>(true,"OK");
        }

        private static Tuple<bool, string> ErrorResult(string message)
        {
            return new Tuple<bool, string>(false, message);
        }

        private static Tuple<bool, string> ErrorResult(object validator, Type entityType)
        {
            var errorsProperty = entityType.GetProperty("Errors");
            var errors = (IList<ValidationFailure>)errorsProperty.GetValue(validator, null);
            return new Tuple<bool, string>(false, errors.Select(e => e.ErrorMessage).SingleOrDefault());
        }

        private static Tuple<bool, string> ValidatorUndefined(string entityName)
        {
            return new Tuple<bool, string>(false, "Validator not defined for entity " + entityName);
        }
    }
}
