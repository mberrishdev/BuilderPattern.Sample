public class UserProfile
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string ProfilePicture { get; set; }
    public bool IsActive { get; set; }
    public string UserName { get; set; }

    public UserProfile(string firstName, string lastName, string email, string phone, string address, string country, DateTime dateOfBirth, string gender, string profilePicture, bool isActive, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
        Country = country;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        ProfilePicture = profilePicture;
        IsActive = isActive;
        UserName = userName;
    }

    public UserProfile(string userName)
        : this(null, null, null, null, null, null, default, null, null, true, userName)
    {
    }


    public UserProfile(string firstName, string lastName)
        : this(firstName, lastName, null, null, null, null, default, null, null, true, null) 
    {
    }


    public UserProfile(string firstName, string lastName, string email, string phone, string address, string country, DateTime dateOfBirth, string gender, string profilePicture, bool isActive)
        : this(firstName, lastName, email, phone, address, country, dateOfBirth, gender, profilePicture, isActive, null)
    {
    }
}
