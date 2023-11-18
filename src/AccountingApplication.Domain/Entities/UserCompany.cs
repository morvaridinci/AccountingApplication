using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApplication.Domain.Entities
{
    public class UserCompany
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
