using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCESI.Model.Data
{
    public class StudyCesiContext : IdentityDbContext
    {

        public DbSet<BoolAnswer> BoolAnswers { get; set; }
        public DbSet<ChoiceAnswer> ChoiceAnswers{ get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<HoleAnswer> HoleAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TypeQuestion> TypeQuestions { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<UserExamAnswer> UserExamAnswers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public StudyCesiContext(DbContextOptions<StudyCesiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>()
                .Property(s => s.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<BoolAnswer>()
                .Property(b => b.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<ChoiceAnswer>()
                .Property(c => c.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Exam>()
                .Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);


            modelBuilder.Entity<ExamQuestion>()
                .Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<HoleAnswer>()
                .Property(h => h.CreationDate)
                .HasDefaultValue(DateTime.Now);

             modelBuilder.Entity<Question>()
                .Property(q => q.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<HoleAnswer>()
                .Property(h => h.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<TypeQuestion>()
                .Property(t => t.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<UserExam>()
                .Property(u => u.CreationDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<UserExamAnswer>()
                .Property(u => u.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
