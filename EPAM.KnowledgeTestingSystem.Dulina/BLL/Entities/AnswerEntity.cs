using DAL.DataTransferObject;

namespace BLL.Entities
{
    public class AnswerEntity : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}
