namespace Domain.Entities
{
    public class NormalUser
    {
        public string Id { get; set; } = new Guid().ToString();
        public string DisplayName { get; set; } = string.Empty;
    }
}
