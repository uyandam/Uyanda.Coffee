using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Persistence.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int Points { get; set; }
    }
}
