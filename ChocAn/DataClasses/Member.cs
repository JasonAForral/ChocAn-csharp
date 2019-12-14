using System;
using System.Collections.Generic;
using System.Text;

namespace ChocAn.DataClasses
{
    public class Member : User
    {
        public bool Valid { get; set; }

        public Member(params string[] args)
            : base(args)
        {
            Valid = (args.Length > 6) ? IsEqualToValid(args[6]) : true;
        }

        public new void Display()
        {
            Console.WriteLine("Member Information:");
            base.Display();
            Console.WriteLine(" Status: {0}", Valid ? "Valid" : "Suspended");
        }

        public override string this[int i]
        {
            get {
                if (i > USER_SIZE)
                    throw new IndexOutOfRangeException($"Member only has 0 to {USER_SIZE}");
                return (i < USER_SIZE) ? base[i] : (Valid ? "Valid" : "Suspended");
            }
            set
            {

                if (i < USER_SIZE)
                {
                    base[i] = value;
                }
                else if (i == USER_SIZE)
                {
                    IsEqualToValid(value);
                }
                else
                {
                    throw new IndexOutOfRangeException($"Member only has 0 to {USER_SIZE}");
                }
            }
        }

        private static bool IsEqualToValid(string value) => value.Equals("valid", StringComparison.OrdinalIgnoreCase);
    }
}
