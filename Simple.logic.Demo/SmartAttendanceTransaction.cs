namespace Simple.logic.Demo
{

    public class SmartAttendanceTransaction
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }

        public bool IsInAttendance { get; set; }
        public SmartAttendanceInfoPart InfoPart { get; set; }

    }
}
