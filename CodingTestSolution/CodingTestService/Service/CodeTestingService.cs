using CodingTestModel.Models;
using CodingTestService.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestService.Service
{
    public class CodeTestingService : ICodeTestingService
    {
        private readonly CodingTestContext _context;
        public CodeTestingService(CodingTestContext context)
        {
            _context = context;
        }
        public Task<List<networkDetail>> GetAllNetworkDetail()
        {
           return _context.NetworkDetails.ToListAsync();
        }

        public Task<List<chooseCorrectAnswer>> GetAllQuestions()
        {
            return _context.ChooseCorrectAnswers.ToListAsync();
        }

        public Task<List<userDetail>> GetAllUserDetails()
        {
            return _context.UserDetails.ToListAsync();
        }

        public async Task<AnswersDetail> InsertAnswer(AnswersDetail answersDetail)
        {
            answersDetail.Created = DateTime.Now;
            await _context.AnswersDetails.AddAsync(answersDetail);
            await _context.SaveChangesAsync();
            var getuserdetail = _context.UserDetails.Where(c => c.Id == answersDetail.userId).FirstOrDefault();
            var answerdetails = _context.AnswersDetails.Where(c => c.userId == answersDetail.userId).ToList();
            getuserdetail.loss = answerdetails.Where(c => !c.IsCorrect).Count();
            getuserdetail.win = answerdetails.Where(c => c.IsCorrect).Count();
            _context.UserDetails.Update(getuserdetail);
            await _context.SaveChangesAsync();
            return answersDetail;
        }
    }
}
