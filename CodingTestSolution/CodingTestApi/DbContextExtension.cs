using CodingTestModel.Models;
using CodingTestService.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTestApi
{
    public static class DbContextExtension
    {
        public static void EnsureSeeded(this CodingTestContext context)
        {
            SeedNetworkData(context);
            SeedUserData(context);
            SeedQuestionAnswer(context);
            SeedAnswer(context);
        }

        public static void SeedNetworkData(CodingTestContext context)
        {
            var networks = context.NetworkDetails.ToList();
            if (networks.Count < 1)
            {
                var networkList = new List<networkDetail>
                {
                    new networkDetail {code = "4F6I",name = "Library_Network_4G", Created=DateTime.Now},
                };
                context.NetworkDetails.AddRange(networkList);
                context.SaveChanges();
            }
        }

        public static void SeedUserData(CodingTestContext context)
        {
            var userDetails = context.UserDetails.ToList();
            if (userDetails.Count < 1)
            {
                var userDetailList = new List<userDetail>
                {
                    new userDetail {userName = "test1",loss = 0, win = 0,number = 123, Created=DateTime.Now},
                    new userDetail {userName = "test2",loss = 0, win = 0,number = 423, Created=DateTime.Now},
                    new userDetail {userName = "test3",loss = 0, win = 0,number = 562, Created=DateTime.Now},

                };
                context.UserDetails.AddRange(userDetailList);
                context.SaveChanges();
            }
        }

        public static void SeedQuestionAnswer(CodingTestContext context)
        {
            var questions = context.ChooseCorrectAnswers.ToList();
            if (questions.Count < 1)
            {
                var questionList = new List<chooseCorrectAnswer>
                {
                    new chooseCorrectAnswer {question = "capital of australia?",option1 = "Canberra",option2 = "Victoria",option3 = "Queensland",option4="Tasmania",correctOption = "Canberra", image = "0x6100730064006600", Created=DateTime.Now},

                };
                context.ChooseCorrectAnswers.AddRange(questionList);
                context.SaveChanges();
            }
        }

        public static void SeedAnswer(CodingTestContext context)
        {
            var questions = context.AnswersDetails.ToList();
            var user1 = context.UserDetails.Where(c=>c.userName == "test1").FirstOrDefault();
            var user2 = context.UserDetails.Where(c => c.userName == "test2").FirstOrDefault();
            var question = context.ChooseCorrectAnswers.FirstOrDefault();

            if (questions.Count < 1)
            {
                var AnswersDetailsList = new List<AnswersDetail>
                {
                    new AnswersDetail {userId = user1.Id,questionId = question.Id,IsCorrect = true, Created=DateTime.Now},
                    new AnswersDetail {userId = user2.Id,questionId = question.Id,IsCorrect = false, Created=DateTime.Now},
                };
                context.AnswersDetails.AddRange(AnswersDetailsList);
                context.SaveChanges();

                foreach (var answersDetail in AnswersDetailsList)
                {
                    var getuserdetail = context.UserDetails.Where(c => c.Id == answersDetail.userId).FirstOrDefault();
                    var answerdetails = context.AnswersDetails.Where(c => c.userId == answersDetail.userId).ToList();
                    getuserdetail.loss = answerdetails.Where(c => !c.IsCorrect).Count();
                    getuserdetail.win = answerdetails.Where(c => c.IsCorrect).Count();
                    context.Database.ExecuteSqlRaw("sp_SaveUserDetails @p0,@p1,@p2", getuserdetail.Id, getuserdetail.loss, getuserdetail.win);
                }
               
            }
        }

    }
}
