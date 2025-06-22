using System.Text.Json.Serialization;

namespace TestAssignment.Exceptions
{
    public class PersonNotFoundException : Exception
    {
        public string PersonName { get; }

        public PersonNotFoundException(string personName)
            : base($"Person '{personName}' not found.")
        {
            PersonName = personName;
        }
    }

}
