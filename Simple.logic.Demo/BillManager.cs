namespace Simple.logic.Demo
{
    public class BillManager
    {
        public Bill? Find(int id) { Console.WriteLine(nameof(Find)); return id == 1 ? new Bill() : null; }
        public void Add(Bill bill) { Console.WriteLine(nameof(Add)); }
        public void Update(Bill bill) { Console.WriteLine(nameof(Update)); }
        public void Archive(Bill bill) { Console.WriteLine(nameof(Archive)); }
        public void SaveToDb(Bill bill)
        {
            Console.WriteLine("////////////Save To Db Start/////////////");
            Console.WriteLine("make complex query1");
            Console.WriteLine("make complex logic");
            Console.WriteLine("make complex Save to multiple statistics table");
            Console.WriteLine("notify other services");
            Console.WriteLine("if notify fails try again");
            Console.WriteLine("if notify fails again - use scheduled job (outbox pattern) to try at later time");
            Console.WriteLine("////////////Save To Db End/////////////");

        }
    }
}
