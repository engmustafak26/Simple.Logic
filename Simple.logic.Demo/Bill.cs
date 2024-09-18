namespace Simple.logic.Demo
{
    public class Bill
    {
        public int Id { get; set; } = 1;
        public string Customer { get; set; }
        public bool IsCompleted { get; set; }

        public bool IsBillCompleted() { Console.WriteLine(nameof(IsBillCompleted)); return IsCompleted; }
    }
}
