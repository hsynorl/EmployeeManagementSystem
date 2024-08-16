using EmployeeManagementSystem.DataAccess.Context;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.Entities.Entities;

namespace EmployeeManagementSystem.DataAccess.Repositories.Concrete
{
    public class UserDepartmentRepository : GenericRepository<UserDepartment>, IUserDepartmentRepository
    {
        public UserDepartmentRepository(EmployeeManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
