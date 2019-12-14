﻿using System;
using System.Collections.Generic;

namespace ChocAn.DataClasses
{
    public class Provider : User
    {
        private readonly List<string> services;

        public Provider(params string[] args)
            : base(args)
        {

            for (int i = USER_SIZE; i < args.Length; ++i)
            {
                services.Add(args[i]);
            }
        }

        public new void Display()
        {
            Console.WriteLine("Provider Information:");
            base.Display();
            Console.WriteLine("Services:");
            foreach (string service in services)
            {
                Console.WriteLine(service);
            }
        }

        public override string this[int i]
        {
            get {
                if (i > USER_SIZE + services.Count)
                    throw new IndexOutOfRangeException($"Provider only has 0 to {USER_SIZE + services.Count}");
                return (i < USER_SIZE) ? base[i] : services[i - USER_SIZE];
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
