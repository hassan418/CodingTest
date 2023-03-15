using System.Collections.Generic;

namespace CodingTestModel.Models
{
    public class userDetail : baseEntity
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int number { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
        public virtual IEnumerable<AnswersDetail> answersDetails { get; set; }
    }
}
