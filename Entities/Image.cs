namespace RoyalEstateBackend.Entities
{
    public class Image
    {
        public int Id{get; set;}
        public string Path{get; set;}
        public int PropertyId{get; set;}
        public Property Property{get; set;}
    }
}