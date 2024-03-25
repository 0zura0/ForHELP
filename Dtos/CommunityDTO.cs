namespace Reddit.Dtos
{
    public class CreateCommunityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
    }
}