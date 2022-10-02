using Newtonsoft.Json;

namespace RestAPITest.TestSolution.Models
{
    internal class ResponceUser
    {
        public ResponceUser()
        {
        }

        public ResponceUser(int id, string name, string email, string gender, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Gender = gender;
            this.Status = status;
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
