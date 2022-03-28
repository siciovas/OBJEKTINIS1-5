using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class Shop
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public JuvelryContainer AllJuvelry { get; set; }
        

        public Shop(string title, string address, string phoneNumber)
        {
            Title = title;
            Address = address;
            PhoneNumber = phoneNumber;
            AllJuvelry = new JuvelryContainer(20);
        }

        public void AddRing(Ring ring)
        {
            AllJuvelry.AddJuvelry(ring);
        }

        public void AddEarrings(Earrings earrings)
        {
            AllJuvelry.AddJuvelry(earrings);
        }

        public void AddCollar(Collar collar)
        {
            AllJuvelry.AddJuvelry(collar);
        }
    }
}
