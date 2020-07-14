using System;
using System.Collections.Generic;
using PubCompanyWinCore.IView;
using BLL;
using Entities;

namespace PubCompanyWinCore.Presenters
{
    public class PayRollViewPresenter
    {
        private IPayRollView mView;
        private IPayRollDM _payRollDm;
        private IAuthorDM _authorDm;

        public PayRollViewPresenter(IPayRollView payRollView, IPayRollDM payRollDm, IAuthorDM authorDm)
        {
            mView = payRollView;
            _payRollDm = payRollDm;
            _authorDm = authorDm;
            this.Initialize();
        }

        private void Initialize()
        {
            this.mView.Add += new EventHandler<EventArgs>(mView_Add);
            this.mView.UPdate += new EventHandler<EventArgs>(mView_Update);
            this.mView.Delete += new EventHandler<EventArgs>(mView_Delete);
        }

        public List<DtoAuthor> GetAuthors()
        {
            return _authorDm.GetAuthors();
        }

        public DtoPayRoll FindPayRollByAuthorId(int id)
        {
            return _payRollDm.FindPayRollByAuthorId(id);
        }
        private void mView_Add(object sender, EventArgs e)
        {
            var dto = new DtoPayRoll { AuthorId = mView.AuthorId, Salary = mView.Salary };
            mView.Message = _payRollDm.Add(dto);
        }

        private void mView_Update(object sender, EventArgs e)
        {
            var dto = new DtoPayRoll {PayrollId = mView.PayrollId, AuthorId = mView.AuthorId, Salary = mView.Salary};
            _payRollDm.Update(dto);
            mView.Message = "Payroll updated.";
        }

        private void mView_Delete(object sender, EventArgs e)
        {
            _payRollDm.Delete(mView.PayrollId);
            mView.Message = "Payroll deleted.";
        }
    }
}
