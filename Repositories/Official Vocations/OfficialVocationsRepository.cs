using HR_System.DTOs.OfficialvocationDto;
using HR_System.Models;

namespace HR_System.Repositories.Official_Vocations
{
    public class OfficialVocationsRepository:IOfficialVocationsRepository
    {
        private readonly HREntity hREntity;
        public OfficialVocationsRepository(HREntity hREntity)
        {
            this.hREntity = hREntity;
        }
        public Models.OfficialVocations GetByID(int id)
        {
           return hREntity.OfficialVocations.FirstOrDefault(o =>o.ID==id && o.IsDeleted!=true);
        }
        public List<OfficialVocationDto> GetAll()
        {
            var vocations = hREntity.OfficialVocations.Where(o => o.IsDeleted!=true).ToList();
            var vocationsDto = vocations.Select(o => new OfficialVocationDto()
            {
                ID = o.ID,
                Name = o.Name,
                Date = o.Date,
            }).ToList();
            return (vocationsDto);
        }
        public OfficialVocationDto GetVocationById(int id) {
            var vocation = GetByID(id);
            var voctionDto = new OfficialVocationDto();
            voctionDto.ID = vocation.ID;
            voctionDto.Name = vocation.Name;
            voctionDto.Date = vocation.Date;
            return (voctionDto);
        }

        public int Insert(OfficialVocationDto vocationDto)
        {
            var Vocation = new Models.OfficialVocations
            {
                Name = vocationDto.Name,
                Date = vocationDto.Date,
            };
            var all = GetAll();
            foreach (var o in all)
            {
                if (o.Name == Vocation.Name || o.Date==Vocation.Date)
                {
                    return 0;
                }
            }
            hREntity.Add(Vocation);
            hREntity.SaveChanges();
            return 1;
        }
        public void Update(OfficialVocationDto vocationDto)
        {
            var Vocation = new Models.OfficialVocations
            {
                ID= vocationDto.ID,
                Name = vocationDto.Name,
                Date = vocationDto.Date,
            };
            hREntity.Update(Vocation);
            hREntity.SaveChanges();
        }

        public void Delete (int id)
        {
            var OldVocation = GetByID(id);
            if (OldVocation != null)
            {
                OldVocation.IsDeleted = true;
                hREntity.SaveChanges();
            }
        }

        public int ifVocation(int day, int month ,int year)
        {
            var vocations = hREntity.OfficialVocations.Where(o =>o.Date.Day==day && o.Date.Month==month && o.Date.Year==year && o.IsDeleted != true).ToList();
            if (vocations.Count() == 0)
            {
                return 0;      //isnont vaction
            }
            else { return 1; }

        }
    }
}
