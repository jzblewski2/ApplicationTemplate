using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Models
{
    public class Video : Media
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public string Regions { get; set; }

        public override string Display()
        {
            return $"ID: {Id}, Title: {Title}, Format: {Format}, Length: {Length}, Regions: {Regions}";
        }
    }
}
