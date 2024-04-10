﻿using System.ComponentModel.DataAnnotations;

namespace Wj.Bizlogic.Validation
{
    public interface IObjectValidator
    {
        Task ValidateAsync(
            object validatingObject,
            string? name = null,
            bool allowNull = false
        );

        Task<List<ValidationResult>> GetErrorsAsync(
            object validatingObject,
            string? name = null,
            bool allowNull = false
        );
    }
}

