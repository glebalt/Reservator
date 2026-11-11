using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    public class RoomID
    {

        public int FloorNumber { get; }

        public int RoomNumber { get; }


        public RoomID(int fn,int rn)
        {
            FloorNumber= fn;
            RoomNumber = rn;
        }

        public override string ToString()
        {
            return $"{FloorNumber} {RoomNumber}";
        }

        public override bool Equals(object? obj)
        {
            RoomID roomID = null;

            if (obj is RoomID)
            {
                roomID = (RoomID)obj;
            }
            else
            {
                Console.WriteLine("Passed object is null");
                return false;
            }

            return obj is RoomID && FloorNumber == roomID.FloorNumber && RoomNumber == roomID.RoomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }
    }
}
