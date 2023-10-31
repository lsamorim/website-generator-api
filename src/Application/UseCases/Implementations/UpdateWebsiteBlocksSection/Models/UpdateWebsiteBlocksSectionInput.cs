namespace Application.UseCases.Implementations.UpdateWebsiteBlocksSection.Models
{
    public class UpdateWebsiteBlocksSectionInput
    {
        public string Key { get; set; }

        public int SectionId { get; set; }

        public dynamic Block { get; set; }

        public UpdateWebsiteBlocksSectionInput(string key, int sectionId, dynamic block)
        {
            Key = key;
            SectionId = sectionId;
            Block = block;
        }

    }
}
