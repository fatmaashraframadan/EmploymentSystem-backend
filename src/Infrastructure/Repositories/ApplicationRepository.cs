using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ApplicationAggregate;
using EmploymentSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        public Task AddApplicationAsync(Application application)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApplicationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetApplicationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationAsync(Application application)
        {
            throw new NotImplementedException();
        }
    }
}