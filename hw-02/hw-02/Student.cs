using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace hw_02
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {

            if (!(obj is Student))
            {
                return false;
            }
            if (this.GetHashCode() != obj.GetHashCode())
            {
                return false;
            }
            return this.Jmbag.Equals(((Student)obj).Jmbag);
        
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static bool operator ==(Student s1, Student s2)
        {
            if (object.ReferenceEquals(s1, null))
            {
                return object.ReferenceEquals(s2, null);
            }
            if (object.ReferenceEquals(s2, null))
            {
                return false;
            }
            return s1.Jmbag.Equals(s2.Jmbag);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
    }

    

    public enum Gender
    {
        Male, Female
    }
}