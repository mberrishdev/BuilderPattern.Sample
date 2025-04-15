namespace BuilderPattern.Sample.Domain.Builder;

public class UserProfile
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string Country { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Gender { get; private set; }
    public string ProfilePicture { get; private set; }
    public bool IsActive { get; private set; }
    public string UserName { get; private set; }

    private UserProfile(UserProfileBuilder builder)
    {
        FirstName = builder.FirstName;
        LastName = builder.LastName;
        Email = builder.Email;
        Phone = builder.Phone;
        Address = builder.Address;
        Country = builder.Country;
        DateOfBirth = builder.DateOfBirth;
        Gender = builder.Gender;
        ProfilePicture = builder.ProfilePicture;
        IsActive = builder.IsActive;
        UserName = builder.UserName;
    }

    public class UserProfileBuilder
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string Country { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string ProfilePicture { get; private set; }
        public bool IsActive { get; private set; }
        public string UserName { get; private set; }

        public UserProfileBuilder(string userName)
        {
            UserName = userName; 
            IsActive = true;   
        }

        public UserProfileBuilder SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            return this;
        }

        public UserProfileBuilder SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserProfileBuilder SetPhone(string phone)
        {
            Phone = phone;
            return this;
        }

        public UserProfileBuilder SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public UserProfileBuilder SetCountry(string country)
        {
            Country = country;
            return this;
        }

        public UserProfileBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            return this;
        }

        public UserProfileBuilder SetGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public UserProfileBuilder SetProfilePicture(string profilePicture)
        {
            ProfilePicture = profilePicture;
            return this;
        }

        public UserProfileBuilder SetIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public UserProfile Build()
        {
            return new UserProfile(this);
        }
    }
}
