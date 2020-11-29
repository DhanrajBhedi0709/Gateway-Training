using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web;

namespace sourcecontrolassignment1.Models
{
    [Bind(Exclude = "Id")]
    public class DetailModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50)]
        [sourcecontrolassignment1.CustomAttribute.MinName(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DisplayName("Confim Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password Not Matched")]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Birthdate is Required")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [sourcecontrolassignment1.CustomAttribute.MinAge(18)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage ="Letters Should be less 200.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "MobileNo is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Enter valid Phone number Eg. 91-1234-567-890")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "CreditCard is Required")]
        [DisplayName("Credit Card")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Url]
        [DisplayName("Profile Url")]
        [Required(ErrorMessage = "Any Profile Url is Required")]
        public string Linkdin { get; set; }        
    }
}