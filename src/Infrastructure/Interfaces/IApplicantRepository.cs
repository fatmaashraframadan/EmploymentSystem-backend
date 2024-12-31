using Domain.UserAggregate;

namespace Infrastructure.Repositories
{
    public interface IApplicantRepository
    {
        Task<Applicant> GetApplicantByIdAsync(Guid id);
        Task<IEnumerable<Applicant>> GetApplicantsAsync();
        Task<Applicant> AddApplicantAsync(Applicant applicant);
        Task<Applicant> UpdateApplicantAsync(Applicant applicant);
        Task DeleteApplicantAsync(Guid id);
    }
}