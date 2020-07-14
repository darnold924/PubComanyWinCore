using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using Entities;
using PubCompanyWinCore.IView;

namespace PubCompanyWinCore.Presenters
{
    
    public class AuthorViewPresenter
    {
        private IAuthorView mView;
        private IAuthorDM _authorDm;

        public AuthorViewPresenter(IAuthorView authorView, IAuthorDM authorDm)
        {
            mView = authorView;
            _authorDm = authorDm;
            this.Initialize();
        }

        private void Initialize()
        {
            this.mView.Send += new EventHandler<EventArgs>(mView_Send);
            this.mView.Delete += new EventHandler<EventArgs>(mView_Delete);
        }

        private void mView_Delete(object sender, EventArgs e)
        {
            mView.Message = _authorDm.Delete(mView.AuthorId);
        }

        private void mView_Send(object sender, EventArgs e)
        {
            var dto = new DtoAuthor{AuthorId = mView.AuthorId, FirstName = mView.FirstName, LastName = mView.LastName};

            if (dto.AuthorId > 0)
            {
                mView.Message = _authorDm.Update(dto);
            }
            else
            {
                mView.Message = _authorDm.Add(dto);
            }
        }

        public List<DtoAuthor> GetAuthors()
        {
            return _authorDm.GetAuthors();
        }
    } 
}
