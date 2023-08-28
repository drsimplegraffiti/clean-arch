using System;
namespace CleanMovie.Domain
{
	public class Member
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

		//link One to many
		public int RentalId { get; set; }
		public Rental Rental { get; set; }
	}
}

