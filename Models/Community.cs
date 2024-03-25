using System.ComponentModel.DataAnnotations.Schema;

namespace Reddit.Models
{
    public class Community
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }




        // Navigation property to Owner

        public virtual int OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }




        public virtual ICollection<Post> Posts { get; set; }  //one to many

        public virtual ICollection<User> UserSubscribers { get; set; } //many to many
    }
}
