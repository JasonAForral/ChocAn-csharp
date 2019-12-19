using System;
using System.Collections.Generic;
using System.Text;

namespace ChocAn.DataClasses
{
    public abstract class User
    {
        protected const int USER_SIZE = 6;
        private readonly string[] _data;

        public User(params string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length < USER_SIZE)
                throw new ArgumentException("Requires at least 6 fields", nameof(args));

            _data = new string[USER_SIZE];
            Array.Copy(args, _data, USER_SIZE);
        }

        public void Display()
        {

            Console.WriteLine($" ID: {_data[1]}");
            Console.WriteLine($" {_data[0]}");
            Console.WriteLine($" {_data[2]}");
            Console.WriteLine($" {_data[3]}, {_data[4]} {_data[5]}");
        }

        public string[] GetAll()
        {
            string[] data = new string[USER_SIZE];
            Array.Copy(_data, data, USER_SIZE);
            return data;
        }

        public virtual string this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }
    }
}
