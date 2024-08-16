using EmployeeManagementSystem.DataAccess.Context;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.Entities.Entities;

namespace EmployeeManagementSystem.DataAccess.Repositories.Concrete
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
