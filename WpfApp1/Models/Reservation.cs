using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WpfApp1.Models
{
        public class Reservation
    {
        public RoomID RoomID {  get; }
        public string UserName { get; }
        public DateTime start { get; }
        public DateTime end { get; }

        //public TimeSpan len => end - start;

        public Reservation(RoomID id,DateTime s,DateTime e,string un) {
            RoomID = id;
            start = s;
            end = e;
            UserName = un;
        }

        public bool Conflicts(Reservation incRes)
        {
            System.Diagnostics.Debug.WriteLine($"incoming res {incRes.start.Day} existing {this.start.Day}");
            if (!incRes.RoomID.Equals(RoomID))
            {
                return false;
            }
         
            if (incRes.start >= start && incRes.start <= end ) return true;
            
            if(incRes.end >= start && incRes.end <= end ) return true;
            

            return false;
        }
    }
}
