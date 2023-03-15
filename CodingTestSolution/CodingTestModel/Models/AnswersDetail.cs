using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestModel.Models
{
    public class AnswersDetail : baseEntity
    {
        public int questionId { get; set; }
        public bool IsCorrect { get; set; }
        public int userId { get; set; }
        public virtual userDetail userDetails { get; set; }
        public virtual chooseCorrectAnswer  chooseCorrectAnswers { get; set; }

    }
}
