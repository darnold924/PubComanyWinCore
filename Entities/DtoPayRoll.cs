namespace Entities
{
    public class DtoPayRoll
    {
        public int PayrollId { get; set; }
        public int AuthorId { get; set; }
        public int? Salary { get; set; }

        public virtual DtoAuthor DtoAuthor { get; set; } = new DtoAuthor();

    }
}
