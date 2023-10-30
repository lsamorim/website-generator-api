namespace Domain.Components.Blocks
{
    public class HeaderBlock : Block
    {
        public static string Id => nameof(HeaderBlock);
        public int BlockOrder { get; set; }

        public string BusinessName { get; set; }
        public bool LogoVisible { get; set; }
        public NavigationMenu NavigationMenu { get; set; }
        public CTAButton Button { get; set; }
    }
}
