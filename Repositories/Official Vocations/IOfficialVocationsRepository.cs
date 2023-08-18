using HR_System.DTOs.OfficialvocationDto;
using HR_System.Models;

namespace HR_System.Repositories.Official_Vocations
{
    public interface IOfficialVocationsRepository
    {
        Models.OfficialVocations GetByID(int id);
         List<OfficialVocationDto> GetAll();
         OfficialVocationDto GetVocationById(int id);
         int Insert(OfficialVocationDto vocationDto);
        void Update(OfficialVocationDto vocationDto);
         void Delete(int id);
        int ifVocation(int day, int month, int year);


        }
}
