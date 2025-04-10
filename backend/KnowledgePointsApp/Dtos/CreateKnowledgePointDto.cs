namespace KnowledgePointsApp.Dtos
{
    public class CreateKnowledgePointDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}