namespace RoyalEstateBackend.Dtos
{
    public class AddressDto
    {
        public string Street{get; set;}
        public string Description{get; set;}
        public string LocalGovt{get; set;}
        public string State{get; set;}
        public string Country{get; set;}
        public int PropertyId{get; set;}
    }
}