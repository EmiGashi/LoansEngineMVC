using LoansEngineMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoansEngineMVC.Dtos
{
    public class AddUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string Webinar { get; set; }

    }
}



