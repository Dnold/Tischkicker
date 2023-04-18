namespace Tischkicker.Data
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterModel
    {
        [Required(ErrorMessage = "'Benutzername' ist ein Pflichtfeld")]
        public string Username { get; set; }

        [Required(ErrorMessage = "'Email' ist ein Pflichtfeld")]
        [EmailAddress(ErrorMessage = "Diese Email ist ungültig")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'Passwort ist ein Pflichtfeld'")]
        [MinLength(6, ErrorMessage = "Das Passwort muss aus mindestens 6 Zeichen bestehen")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }
    }
}
