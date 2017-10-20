using System;
namespace FunctionalSandBox
{
    public class Person
    {
        public readonly string _name;
        public  int _age;
        public Person(string name, int age){
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"<Name: {_name}, Age: {_age}>";
        }
    }
}
