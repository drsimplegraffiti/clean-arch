using System;
namespace CleanMovie.Domain
{
	public class Rental
	{
		public int RentalId { get; set; }
		public DateTime RentalDate { get; set; }
        public DateTime RentalExpiry { get; set; }
        public decimal TotalCost { get; set; }

		//link one to many relationship
		public ICollection<Member> Members { get; set; }

        //link --> MANY TO MANY Relationship
        public IList<MovieRental> MovieRentals { get; set; }
    }
}

