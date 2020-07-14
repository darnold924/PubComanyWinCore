using System;
using System.Collections.Generic;
using Entities;

namespace PubCompanyWinCore.IView
{
    public interface IPayRollView
    {
        int PayrollId { get; set; }
        int AuthorId { get; set; }
        int? Salary { get; set; }
        string Message { get; set; }
        List<DtoAuthor> GetAuthors();
        DtoPayRoll FindPayRollByAuthorId(int id);

        event EventHandler<EventArgs> Add;
        event EventHandler<EventArgs> UPdate;
        event EventHandler<EventArgs> Delete;
    }
}


