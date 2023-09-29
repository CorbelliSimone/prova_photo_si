namespace AddressBooksService.Service.AddressBook.Dto
{
    public class AddressBookResponseDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Cap { get; set; }
        public string StreetNumber { get; set; }
        public int CityId { get; set; }
    }
}
