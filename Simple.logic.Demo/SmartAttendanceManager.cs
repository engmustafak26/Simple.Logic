namespace Simple.logic.Demo
{
    public class SmartAttendanceManager
    {
        public Employee? GetEmployee(string biometricProfile)
        {
            Console.WriteLine("Get employee by biometric profile");
            return biometricProfile == "12345" ? new Employee
            {
                Id = 1,
                Name = "employee1",
                BiometricProfile = biometricProfile,
            }: null;
        }
        public void NotifyUIIfEmployeeNotEligibleForSmartAttendance()
        {
            Console.WriteLine("Notify UI If Employee Not Eligible For Smart Attendance");
        }

        public int? GetEmployeeClosestAttendanceLocationId(float lat, float lng)
        {
            Console.WriteLine("Get closest attendance location to employee based on allowed distance diameter");
            return 1;
        }

        public void SaveAttendanceInDb()
        {
            Console.WriteLine("Save new attendance transaction in Db");
        }

        public void NotifyUI()
        {
            Console.WriteLine("Notify UI with attendance Success");
        }
    }

}
