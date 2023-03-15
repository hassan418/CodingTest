using CodingTestModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestService.Service
{
    public interface ICodeTestingService
    {
        Task<AnswersDetail> InsertAnswer(AnswersDetail answersDetail);
        Task<List<userDetail>> GetAllUserDetails();
        Task<List<chooseCorrectAnswer>> GetAllQuestions();
        Task<List<networkDetail>> GetAllNetworkDetail();
    }
}
