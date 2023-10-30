namespace Domain.Components.Blocks
{
    public class HeroBlock : Block
    {
        public static string Id => nameof(HeroBlock);
        public int BlockOrder { get; set; }

        public string HeadlineText { get; set; }
        public string DescriptionText { get; set; }
        public CTAButton Button { get; set; }
        public string HeroImage { get; set; }
        public string ImageAlignment { get; set; }
        public string ContentAlignment { get; set; }
    }
}
