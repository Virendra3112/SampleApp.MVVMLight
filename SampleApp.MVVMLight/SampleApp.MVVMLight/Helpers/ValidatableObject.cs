using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleApp.MVVMLight.Helpers
{
    public class ValidatableObject<T> : IValidatable<T>
    {
        public List<IValidationRule<T>> Validations => throw new NotImplementedException();

        public List<string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsValid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
