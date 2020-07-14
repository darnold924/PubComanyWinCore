using Entities;
using DAL;

namespace BLL
{
    public class PayRollDM : IPayRollDM
    {
        private IDaoPayroll _daoPayroll;
        public PayRollDM(IDaoPayroll daoPayroll)
        {
            _daoPayroll = daoPayroll;
        }
    
        public DtoPayRoll FindPayRollByAuthorId(int id)
        {
            return _daoPayroll.FindPayRollByAuthorId(id);
        }

        public string Add(DtoPayRoll dto)
        {
            if (dto.Salary == 0)
                return "Salary cannot = 0.";
            
            _daoPayroll.Add(dto);
            return "Payroll Added.";
        }

        public void Update(DtoPayRoll dto)
        {
            _daoPayroll.Update(dto);
        }

        public void Delete(int id)
        {
            _daoPayroll.Delete(id);
        }
    }
}
