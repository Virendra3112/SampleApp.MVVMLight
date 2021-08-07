using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.MVVMLight.Helpers
{
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Check(T value)
        {
            throw new NotImplementedException();
        }
    }
}
