namespace RoyalEstateBackend.Entities
{
    public class Address
    {
        public int Id{get; set;}
        public string Street{get; set;}
        public string Description{get; set;}
        public string LocalGovt{get; set;}
        public string State{get; set;}
        public string Country{get; set;}
        public Property Property{get; set;}
    }
}