namespace Semaine_6___ASP.NET_Core___Students_API_Controllers.Models
{
    public class Student
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public int Id { get { return _id; } set { _id = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public DateTime BirthDate { get { return _birthDate; } set { _birthDate = value; } }
    }
}
