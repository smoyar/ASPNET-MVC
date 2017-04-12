using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework1.Models
{
    public class BirthdayCard
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Sender { get; set; }
        [Required(ErrorMessage ="Please enter the name of the person to whom you want to send the card")]
        public string Addressee { get; set; }
        [Required(ErrorMessage ="A message is required")]
        public string Message { get; set; }
    }
}