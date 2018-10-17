using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Data.Domain
{
    public class BaseEntity
    {
        public int ID { get; set; }

        private DateTime Date = DateTime.Now;

        private bool ActiveValue = true;

        public DateTime RegistrationDate
        {
            get { return Date; }
            set { Date = value; }
        }

        public bool IsActive
        {
            get { return ActiveValue; }
            set { ActiveValue = value; }
        }
    }
}
