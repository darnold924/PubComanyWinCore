using DAL.Models;
using System;
using Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class DaoPayroll :IDaoPayroll
    {
        private PublishingCompanyContext pc;
        private IDaoAuthor _daoauthor;

        public DaoPayroll(PublishingCompanyContext dbcontext, IDaoAuthor daoAuthor)
        {
            pc = dbcontext;
            _daoauthor = daoAuthor;
        }

        public List<DtoPayRoll> GetAll()
        {
            var dtos = new List<DtoPayRoll>();

            var payrolls = pc.Payroll.AsNoTracking().ToList();

            foreach (var payroll in payrolls)
            {
                var dtoauthor =  _daoauthor.Find(payroll.AuthorId); 

                var dto = new DtoPayRoll
                {
                    PayrollId = payroll.PayrollId,
                    AuthorId = payroll.AuthorId,
                    Salary = payroll.Salary
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public DtoPayRoll Find(int id)
        {
            var dto = new DtoPayRoll();

            var payroll = pc.Payroll.AsNoTracking().SingleOrDefault(a => a.PayrollId == id);

            if (payroll != null)
            { 
                dto.PayrollId = payroll.PayrollId;
                dto.AuthorId = payroll.AuthorId;
                dto.Salary = payroll.Salary;
               
            }
            else
            {
                throw new Exception($"Payroll with ID = {id} was not found.");
            }

            return dto;

        }

        public DtoPayRoll FindPayRollByAuthorId(int id)
        {
            var dto = new DtoPayRoll {Salary = 0};
             
            var payroll = pc.Payroll.AsNoTracking().SingleOrDefault(a => a.AuthorId == id);

            if (payroll != null)
            {
                dto.PayrollId = payroll.PayrollId;
                dto.AuthorId = payroll.AuthorId;
                dto.Salary = payroll.Salary;
            }

            return dto;
        }

        public void Add(DtoPayRoll dto)
        {
            var payroll = new Payroll
            {
                AuthorId = dto.AuthorId,
                Salary = dto.Salary
            };

            pc.Payroll.Add(payroll);
            pc.SaveChanges();
        }

        public void Update(DtoPayRoll dto)
        {
            var payroll = pc.Payroll.Single(a => a.PayrollId == dto.PayrollId);

            payroll.AuthorId = dto.AuthorId;
            payroll.Salary = dto.Salary;
            
            pc.SaveChanges();
        }

        public void Delete(int id)
        {
            var payroll =  pc.Payroll.AsNoTracking().SingleOrDefault(a => a.PayrollId == id);

            if (payroll != null)
            {
                pc.Payroll.Remove(payroll);
                pc.SaveChanges();
            }
        }
    }
}
