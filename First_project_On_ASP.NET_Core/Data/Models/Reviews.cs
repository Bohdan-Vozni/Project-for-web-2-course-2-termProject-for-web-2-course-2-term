namespace Shop.Data.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        public int orderDetailReturnId { get; set; }

        public OrderDetailReturn orderDetailReturn { get; set; }

        public int grade {  get; set; }

        public string response { get; set; }


    }
}
