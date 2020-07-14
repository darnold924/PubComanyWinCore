using Entities;

namespace BLL
{
    public interface IPayRollDM
    {
        DtoPayRoll FindPayRollByAuthorId(int id);
        string Add(DtoPayRoll dto);
        void Update(DtoPayRoll dto);
        void Delete(int id);
    }
}
