using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DAL.Models;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DaoAuthor : IDaoAuthor
    {
        private PublishingCompanyContext pc;

        public DaoAuthor(PublishingCompanyContext dbcontext)
        {
            pc = dbcontext;
        }

        public List<DtoAuthor> GetAll()
        {
            var dtos = new List<DtoAuthor>();

            var authors =  pc.Author.AsNoTracking().ToList();

            dtos.AddRange(authors.Select(author => new DtoAuthor()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            }).ToList());

            return dtos;
        }

        public DtoAuthor Find(int id)
        {
            var dto = new DtoAuthor();

            var author =  pc.Author.AsNoTracking().SingleOrDefault(a => a.AuthorId == id);

            if (author != null)
            {
                dto.AuthorId = author.AuthorId;
                dto.FirstName = author.FirstName;
                dto.LastName = author.LastName;
            }
            else
            {
                throw new Exception($"Author with ID = {id} was not found.");
            }

            return dto;
        }
       
        public void Add(DtoAuthor dto)
        {
            var author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            pc.Author.Add(author);
            pc.SaveChanges();
        }
        public void Update(DtoAuthor dto)
        {
            var author = pc.Author.Single(a => a.AuthorId == dto.AuthorId);

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            
            pc.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = pc.Author.SingleOrDefault(a => a.AuthorId == id);
                
            if (author != null)
            {
                using (TransactionScope transScope = new TransactionScope())
                {
                    var articles = pc.Article.Where(a => a.AuthorId.ToString().Contains(id.ToString())).ToList();

                    if (articles.Any())
                    {
                        foreach (var article in articles)
                        {
                            pc.Article.Remove(article);
                        }

                        pc.SaveChanges();
                    }

                    var payrolls = pc.Payroll.Where(a => a.AuthorId.ToString().Contains(id.ToString()));

                    if (payrolls.Any())
                    {
                        foreach (var payroll in payrolls)
                        {
                            pc.Payroll.Remove(payroll);
                        }

                        pc.SaveChanges();
                    }

                    pc.Author.Remove(author);
                    pc.SaveChanges();

                    transScope.Complete();
                }
            }
        }
    }
}
