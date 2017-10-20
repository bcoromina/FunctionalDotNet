using System;


namespace FunctionalSandBox
{
    class MainClass
    {
        public static Option.Option<Person> mayBePerson(){
            var p = new Person("Bernat", 37);
            return new Option.Some<Person>(p);
            //return new Option.None<Person>();
        }
        public static Option.Option<int?> mayBeNumber(){
            return new Option.Some<int?>(3);
            //return new Option.None<int?>();
        }

        public static void Main(string[] args)
        {
            var num  = mayBeNumber();

            // pattern matching
            switch(num){
                case Option.Some<int?> v:
                    int? value = v.get();
                    Console.WriteLine($"We have a value: {value}");
                    break;
                case Option.None<int?> v:
                    Console.WriteLine($"We have NO value");
                    break;
            }

            int defaultValue = 33;
            int? numero = num.getOrElse(() => defaultValue );
            Console.WriteLine($"We have a value: {numero}");


            var result = num.map(x => x + 5);

            switch (result)
            {
                case Option.Some<int?> v:
                    int? value = v.get();
                    Console.WriteLine($"We have a value: {value}");
                    break;
                case Option.None<int?> v:
                    Console.WriteLine($"We have NO value");
                    break;
            }

            var per = mayBePerson();
            var perMod = per.map(x => new Person(x._name,20));

            switch(perMod){
                case Option.Some<Person> p:
                    var person = p.get();
                    Console.WriteLine($"We have a person: {person}");
                    break;
                case Option.None<Person> v:
                    Console.WriteLine($"We have NO person");
                    break;
            }

        }
    }
}
