using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DaoArticle :IDaoArticle
    {
        private PublishingCompanyContext pc;
        private IDaoAuthor _daoAuthor;

        public DaoArticle(PublishingCompanyContext dbcontext, IDaoAuthor daoAuthor)
        { 
            pc = dbcontext;
            _daoAuthor = daoAuthor;
        }
        public List<DtoArticle> GetAll()
        {
            var dtos = new List<DtoArticle>();

            var articles = pc.Article.AsNoTracking().ToList();

            dtos.AddRange(articles.Select(article => new DtoArticle()
            {
                ArticleId = article.ArticleId,
                AuthorId = article.AuthorId,
                Title = article.Title,
                Body = article.Body
            }).ToList());

            return dtos;
        }

        public List<DtoArticle> GetArticlesByAuthorId(int id)
        {
            var dtos = new List<DtoArticle>();

            var articles = pc.Article.AsNoTracking().Where(a => a.AuthorId.ToString().Contains(id.ToString()));
           
            foreach (var article in articles)
            {
                var intid = (int)article.AuthorId;

                var dtoauthor =  _daoAuthor.Find(intid);

                var dto = new DtoArticle
                {
                    ArticleId = article.ArticleId,
                    AuthorId = article.AuthorId,
                    AuthorName = dtoauthor.LastName +", " + dtoauthor.FirstName,
                    Title = article.Title,
                    Body = article.Body
                };

                dtos.Add(dto);
            }
             
            return dtos;
        }
        public DtoArticle Find(int id)
        {
            var dto = new DtoArticle();

            var article =  pc.Article.AsNoTracking().SingleOrDefault(a => a.ArticleId == id);
            
            if (article != null)
            {
                dto.ArticleId = article.ArticleId;
                dto.AuthorId = article.AuthorId;
                dto.Title = article.Title;
                dto.Body = article.Body;
            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;

        }

        public void Add(DtoArticle dto)
        {
            var article = new Models.Article
            {
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                Body = dto.Body
            };

            pc.Article.Add(article);
            pc.SaveChanges();

        }

        public void Update(DtoArticle dto)
        {
            var article = new Article
            {
                ArticleId = dto.ArticleId,
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                Body = dto.Body
            };

            pc.Entry(article).State = EntityState.Modified;
            pc.SaveChanges(false);
        }

        public void Delete(int id)
        {
            var article = pc.Article.AsNoTracking().SingleOrDefault(a => a.ArticleId == id);

            if (article != null)
            {
                pc.Article.Remove(article);
                pc.SaveChanges();
            }
        }
    }
}

