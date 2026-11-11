using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;
namespace WpfApp1
{
    public class HotelContainer
    {
        public static Hotel Hotel;

        public HotelContainer(Hotel hotel)
        {
            Hotel = hotel;
        }
    }
}
