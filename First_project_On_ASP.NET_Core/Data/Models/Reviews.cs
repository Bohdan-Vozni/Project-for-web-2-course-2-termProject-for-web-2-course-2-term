using Microsoft.VisualBasic;
using System;

namespace Shop.Data.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public User user { get; set; }

        public int grade {  get; set; }

        public string response { get; set; }

        public string name { get; set; }

        public DateTime timeSend { get; set; }

    }
}
