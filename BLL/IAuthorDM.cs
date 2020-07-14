using System;
using System.Collections.Generic;
using Entities;

namespace BLL
{
    public interface IAuthorDM
    {
        List<DtoAuthor> GetAuthors();
        string Add(DtoAuthor dto);
        string Update(DtoAuthor dto);
        string Delete(int id);

    }
}
