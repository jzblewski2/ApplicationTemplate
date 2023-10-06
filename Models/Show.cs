using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Models
{
    public class Show : Media
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string Writers { get; set; }

        public override string Display()
        {
            return $"ID: {Id}, Title: {Title}, Season: {Season}, Episode: {Episode}, Writers: {Writers}";
        }
    }
}
