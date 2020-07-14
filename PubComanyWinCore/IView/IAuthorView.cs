using System;
using System.Collections.Generic;
using Entities;

namespace PubCompanyWinCore.IView
{
    public interface IAuthorView
    {
        int AuthorId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Message { get; set; }

        event EventHandler<EventArgs> Send;
        event EventHandler<EventArgs> Delete;
        
        List<DtoAuthor> GetAuthors();
    }
}
