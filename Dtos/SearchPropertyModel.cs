namespace RoyalEstateBackend.Dtos
{
    public class SearchPropertyModel
    {
        public string Keyword{get; set;}
        public string Location{get; set;}
        public string PropertyType{get; set;}
        public string PropertyStatus{get; set;}
        public string Utility{get; set;}
        public int UtilityCount{get; set;}
    }
}