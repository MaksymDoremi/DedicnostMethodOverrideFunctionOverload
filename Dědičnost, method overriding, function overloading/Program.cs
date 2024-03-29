namespace Maturita
{
    public class Program
    {

        public static int Calculate(int a)
        {
            return a;
        }

        public static int Calculate(int a, int b)
        {
            return a + b;
        }

        public static int Calculate(int a, int b, bool multiply)
        {
            if (multiply)
            {
                return a * b;
            }

            return a + b;
        }


        public static void Main(string[] args)
        {
            Parent p = new Parent("not inheritable", "inheritable");
            Console.WriteLine(p.MakeAMove());

            Child ch = new Child("chiild action");
            Console.WriteLine(ch.MakeAMove());

            Child ch1 = new Child("not defined inheritable", "some value");
            Console.WriteLine(ch1.MakeAMove());

            /*
                Parent does inheritable action: inheritable and not inheritable: not inheritable
                Child has access to inheritable field: chiild action
                Child has access to inheritable field:

             */
        }
    }

    class Parent
    {
        //private can't be inherited
        private string? not_inheritable;
        //protected is still private but also can be inherited
        protected string? inheritable;
        public Parent(string not_inheritable, string inheritable)
        {
            this.not_inheritable = not_inheritable;
            this.inheritable = inheritable;
        }

        public Parent(string inheritable)
        {
            this.inheritable = inheritable;
        }

        public Parent()
        {

        }

        /// <summary>
        /// Parent method to be overriden, define virtual so it can be overriden
        /// </summary>
        /// <returns></returns>
        public virtual string MakeAMove()
        {
            return "Parent does inheritable action: " + this.inheritable + " and not inheritable: " + this.not_inheritable;
        }
    }

    class Child : Parent
    {
        public Child(string inheritable) : base(inheritable) 
        {
            // we can just define base(fields...) and it will call constructor of Parent(string inheritable)
            // where inheritable gets its value

            //sure we can do this.inheritable = inheritable or do some other stuff in case we need it
        }

        public Child(string inheritable, string value)
        {
            // here we don't call base class, so it will automatically call Parent()
            // so in result no fields are defined and MakeAMove() will print no field
        }

        /// <summary>
        /// Overriden method from <see cref="Parent"> class
        /// </summary>
        /// <returns></returns>
        public override string MakeAMove()
        {
            // note that we don't have access to this.not_inheritable
            return "Child has access to inheritable field: " + this.inheritable;
        }
    }
}