using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sweet.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public Urgency Urgency { get; set; }
    }
    public enum Urgency
    {
        High = 1,
        Med,
        Low
    }
}