using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IDaoArticle
    {
        List<DtoArticle> GetAll();
        List<DtoArticle> GetArticlesByAuthorId(int id);
        DtoArticle Find(int id);
        void Add(DtoArticle dto);
        void Update(DtoArticle dto);
        void Delete(int id);
    }
}
