using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface IDaoPayroll
    {
        List<DtoPayRoll> GetAll();
        DtoPayRoll Find(int id);
        DtoPayRoll FindPayRollByAuthorId(int id);
        void Add(DtoPayRoll dto);
        void Update(DtoPayRoll dto);
        void Delete(int id);
    }
}
