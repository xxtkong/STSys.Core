using STSys.Core.Domain.Core.Commands;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Commands
{
    public class UsersInsertCommand : Command
    {
        public UsersEntities Users { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new UsersValidation().Validate(this.Users);
            return ValidationResult.IsValid;
        }
    }
}
