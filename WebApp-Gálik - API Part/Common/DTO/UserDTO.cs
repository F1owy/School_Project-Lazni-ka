namespace Lukas_Liscak_IVD.Models
{
    public class UserDTO
    {
        public string Surname { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public List<string> ToDo { get; set; } = new List<string>();
        /*public static List<UserModel> AllUsers { get; } = new List<UserModel>();

        public static IEnumerable<UserModel> Each()
        {
            return AllUsers;
        }*/
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
};

