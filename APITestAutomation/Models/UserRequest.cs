namespace APITestAutomation.Models
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class UserRequestWithWrongModel
    {
        public string InvalidKeyOne { get; set; }
        public string InvalidKeyTwo { get; set; }
    }
    
    public class UserResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UserListResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public List<UserData> Data { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

}
