using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IDaoAuthor
    {
        List<DtoAuthor> GetAll();
        DtoAuthor Find(int id);
        void Add(DtoAuthor dto);
        void Update(DtoAuthor dto);
        void Delete(int id);
    }
}
