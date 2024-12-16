using System;
using Rental;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Rental
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Привет Мир!!!");
            using(var db = new Config())
            {

            }
        }
    }
}