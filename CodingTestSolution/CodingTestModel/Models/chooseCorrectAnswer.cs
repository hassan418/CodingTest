using System.Collections.Generic;

namespace CodingTestModel.Models
{
    public class chooseCorrectAnswer : baseEntity
    {
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string correctOption { get; set; }
        public string image { get; set; }
        public virtual IEnumerable<AnswersDetail> answersDetails { get; set; }

    }
}
