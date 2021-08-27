using Manager.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public class User : Base
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }

        //EF
        protected User()
        { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            this.Name = name;
            this.Validate();
        }
        public void ChangeEmail(string email)
        {
            this.Name = email;
            this.Validate();
        }
        public void ChangePassword(string password)
        {
            this.Name = password;
            this.Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validate = validator.Validate(this);

            if (!validate.IsValid)
            {
                foreach (var erro in validate.Errors)
                    _errors.Add(erro.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos");
            }

            return true;
        }
    }
}
