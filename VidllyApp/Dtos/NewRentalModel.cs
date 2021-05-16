using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Models;

namespace VidllyApp.Dtos
{
    public class NewRentalModel
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}