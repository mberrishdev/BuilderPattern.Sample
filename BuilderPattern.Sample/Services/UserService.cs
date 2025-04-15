namespace BuilderPattern.Sample.Services;

public class UserService
{
    public void CreateUser()
    {
        var userProfile1 = new UserProfile("john_doe");

        var userProfile2 = new UserProfile("John", "Doe");

        var userProfile3 = new UserProfile(
            "John", "Doe", "john.doe@example.com", "123-456-7890", "123 Elm St", "Georgia", new DateTime(1990, 5, 1),
            "Male", "profilepic.jpg", true, "john_doe"
        );


        var userProfile4 = new BuilderPattern.Sample.Domain.Builder.UserProfile.UserProfileBuilder("john_doe")
            .SetName("John", "Doe")
            .SetEmail("john.doe@example.com")
            .SetPhone("123-456-7890")
            .SetAddress("123 Elm St")
            .SetCountry("USA")
            .SetDateOfBirth(new DateTime(2002, 12, 12))
            .SetGender("Male")
            .SetProfilePicture("profilepic.jpg")
            .SetIsActive(true)
            .Build();
    }
}