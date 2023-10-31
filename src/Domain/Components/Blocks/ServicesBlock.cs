namespace Domain.Components.Blocks
{
    public class ServicesBlock : IBlock
    {
        public static string Id => nameof(ServicesBlock);
        public int BlockOrder { get; set; }

        public string HeadlineText { get; set; }
        public IEnumerable<ServiceCard> ServiceCards { get; set; } = Array.Empty<ServiceCard>();
    }
}
