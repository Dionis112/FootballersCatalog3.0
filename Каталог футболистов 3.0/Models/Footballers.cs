using System;

namespace Каталог_футболистов_3._0.Models
{
    public class Footballers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string NameTeam { get; set; }
        public string Country { get; set; }//Россия, США, Италия

    }
}

