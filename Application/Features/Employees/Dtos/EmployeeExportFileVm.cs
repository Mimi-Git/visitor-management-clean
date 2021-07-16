namespace Application.Features.Employees
{
    public class EmployeeExportFileVm
    {
        public string EmployeeFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}