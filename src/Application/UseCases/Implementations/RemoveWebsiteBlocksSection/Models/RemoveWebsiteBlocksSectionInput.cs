namespace Application.UseCases.Implementations.RemoveWebsiteBlocksSection.Models
{
    public class RemoveWebsiteBlocksSectionInput
    {
        public string Key { get; set; }

        public int SectionId { get; set; }

        public RemoveWebsiteBlocksSectionInput(string key, int sectionId)
        {
            Key = key;
            SectionId = sectionId;
        }

    }
}
