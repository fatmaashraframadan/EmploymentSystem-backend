using Domain.UserAggregate;

namespace Infrastructure.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        public Task<Applicant> AddApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApplicantAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> GetApplicantByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Applicant>> GetApplicantsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> UpdateApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}