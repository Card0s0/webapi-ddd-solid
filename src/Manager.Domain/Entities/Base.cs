using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        //Message Pathern
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        //Message Pathern

        public abstract bool Validate();
    }
}
