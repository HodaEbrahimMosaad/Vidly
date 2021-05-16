using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Models;

namespace VidllyApp.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}