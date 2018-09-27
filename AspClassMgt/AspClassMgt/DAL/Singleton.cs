using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class Singleton
    {
        private static Context instance;

        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }

                return instance;
            }
        }
    }
}
