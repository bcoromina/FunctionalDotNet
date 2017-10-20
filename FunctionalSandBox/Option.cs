using System;

namespace FunctionalSandBox.Option
{

    public class Option<T> 
    {
        protected T _val;
        public T get(){
            if (_val != null)
                return _val;
            else{
                throw new System.Exception("No value");
            }
        }

        public T getOrElse(Func<T> f){
            if (_val != null)
                return _val;
            else
                return f();
        }

        public Option<A> map<A>(Func<T,A> f){
            if (_val != null)
                return new Option.Some<A>(f(_val));
            else
                return new Option.None<A>();

        }
    }

    public class Some<T> : Option<T>
    {
        public Some(T v){
            _val = v;
        }
    }

    public class None<T> : Option<T>
    {
        public None(){
            if (default(T) != null)
                throw new InvalidOperationException("Option<T> requires T to be a nullable type.");
            _val = default(T);
        }
    }
} 