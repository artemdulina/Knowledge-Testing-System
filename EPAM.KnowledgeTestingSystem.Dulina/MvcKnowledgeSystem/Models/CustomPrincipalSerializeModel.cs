using BLL.Entities;

namespace MvcKnowledgeSystem.Models
{
    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEntity[] roles { get; set; }
    }
}