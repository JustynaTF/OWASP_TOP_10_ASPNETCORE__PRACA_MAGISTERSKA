namespace A01_BrokenAccessControl_IDOR
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
