using System.Collections.Generic;
using DAL;
using DAL.Models;
using Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BLL
{
    public class AuthorDM :IAuthorDM
    {
        private IDaoAuthor _daoAuthor;
        public AuthorDM(IDaoAuthor daoAuthor)
        {
            _daoAuthor = daoAuthor;
        }

        public List<DtoAuthor> GetAuthors()
        {
            return _daoAuthor.GetAll();
        }

        public string Add(DtoAuthor dto)
        {

            if (dto.FirstName == "")
                return "FirstName cannot be blank.";

            if (dto.LastName == "")
                return "LastName cannot be blank.";

            _daoAuthor.Add(dto);

            return "Author was added.";
        }

        public string Update(DtoAuthor dto)
        {
            if (dto.FirstName == "")
                return "FirstName cannot be blank.";

            if (dto.LastName == "")
                return "LastName cannot be blank.";

            _daoAuthor.Update(dto);

            return "Author was updated.";
        }

        public string Delete(int id)
        {
            _daoAuthor.Delete(id);

            return "Author was deleted.";
        }
    }
}
