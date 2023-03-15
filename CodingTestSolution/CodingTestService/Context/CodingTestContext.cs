using CodingTestModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTestService.Context
{
    public class CodingTestContext : DbContext
    {
        public CodingTestContext()
        {
        }

        public CodingTestContext(DbContextOptions<CodingTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnswersDetail> AnswersDetails { get; set; }
        public virtual DbSet<chooseCorrectAnswer> ChooseCorrectAnswers { get; set; }
        public virtual DbSet<networkDetail> NetworkDetails { get; set; }
        public virtual DbSet<userDetail> UserDetails { get; set; }
    }
    
}
