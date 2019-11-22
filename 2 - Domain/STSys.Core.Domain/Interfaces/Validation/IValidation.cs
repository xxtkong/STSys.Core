using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.Interfaces.Validation
{
    public abstract class IValidation<TEntity> :AbstractValidator<TEntity>
    {

    }
}
