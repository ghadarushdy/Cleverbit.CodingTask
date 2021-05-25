using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.BLL
{
    public sealed class GenerateRandomNumber
    {
        GenerateRandomNumber() { }
        private static readonly object lockk = new object();  
        public static GenerateRandomNumber instance = null;
        private Random random = new Random();
        public static GenerateRandomNumber Instance
        {
            get
            {
                lock (lockk)
                    {
                        if (instance == null)
                        {
                            instance = new GenerateRandomNumber();
                        }
                        return instance;
                    }
            }
        }

        public int GetRandomNumber(int max)
        {
            try
            {
                return random.Next(max);
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
