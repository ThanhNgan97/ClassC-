using System.Collections;
using System.Collections.Generic;
using Moq;
using StaffServices.Models;

public class StaffTestingRepository
{
    Mock<IEmployeeRepository> mock;
    StaffsContext staffsContext;
    IEmployeeRepository staffRepository;
    public static List<Employee> expectedList { get; set; }

    public StaffTestingRepository()
    {
        mock = new Mock<IEmployeeRepository>();
        staffsContext = new StaffsContext();
        staffRepository = new EmployeeRepository(staffsContext);
        expectedList = new List<Employee>();
        expectedList.Add(new Employee() { EmployeeId = 1, FirstName = "Tran Hai", LastName = "Dang", StartingDate = new DateTime(2004-02-02), DepartmentId = 1, GenderId = 1, Email = "acb@gmail.com" });
        expectedList.Add(new Employee() { EmployeeId = 2, FirstName = "Nguyen Thanh", LastName = "Ngan", StartingDate = new DateTime(2004-02-02), DepartmentId = 2, GenderId = 2, Email = "xyz@gmail.com" });
    }

    [Fact]
public async void GetStaff()
{
    // Expected staff
    var staff = from emp in expectedList
                where emp.EmployeeId == 2
                select emp;
    var expectedStaff = (staff == null) ? null : staff.FirstOrDefault();

    mock.Setup(x => x.GetEmployeeById(2)).ReturnsAsync(expectedStaff);
    var result = await staffRepository.GetEmployeeById(2); // Revoke the method

    // Assertion
    Assert.Equal(expectedStaff.EmployeeId, result.EmployeeId);
}

}

internal class EmployeeManagementsContext
{
}

internal interface IStaffRepository
{
}

