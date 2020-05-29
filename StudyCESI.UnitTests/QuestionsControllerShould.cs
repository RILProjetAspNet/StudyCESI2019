using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Data;
using StudyCESI.Model.Entities;
using StudyCESI.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace StudyCESI.UnitTests
{
    public class QuestionsControllerShould
    {
        public StudyCesiContext GetFakeContext()
        {
            var options = new DbContextOptionsBuilder<StudyCesiContext>()
                .UseInMemoryDatabase("FakeDatabase")
                .Options;

            var context = new StudyCesiContext(options);

            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                             .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            var question = fixture.Create<Question>();
            context.Questions.Add(question);          

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task Return_Index_View_With_Questions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var QuestionsController = new QuestionsController(GetFakeContext());


            // Act
            var result = await QuestionsController.Index();

            // Assert
            Assert.NotNull(result);           
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var Questions = Assert.IsAssignableFrom<List<Question>>(viewResult.Model);
        }

        [Fact]
        public async Task Return_Edit_View_With_Questions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var QuestionsController = new QuestionsController(context);
            var question = fixture.Create<Question>();
            question.QuestionId = context.Questions.FirstOrDefault().QuestionId;
            // Act
            var result = await QuestionsController.Edit(question.QuestionId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);                

        }

        [Fact]
        public async Task Return_Details_View_With_Questions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var QuestionsController = new QuestionsController(context);
            var question = fixture.Create<Question>();
            question.QuestionId = context.Questions.FirstOrDefault().QuestionId;

            // Act
            var result = await QuestionsController.Details(question.QuestionId);
   
            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Return_Delete_View_With_Questions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var QuestionsController = new QuestionsController(context);
            var question = fixture.Create<Question>();
            question.QuestionId = context.Questions.FirstOrDefault().QuestionId;

            // Act
            var result = await QuestionsController.Delete(question.QuestionId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }


        //[Fact]
        //public async Task Return_Create_View_With_Questions_List()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var mockUser = new Mock<UserManager<User>>();

        //    mockUser.Object.Users = // Users est en lecture seul je n'ai donc pas la main sur mes users et je ne peux donc pas gerer mon create dans le controller voir : _userManager.GetUserId(User);
        //    var QuestionsController = new QuestionsController(GetFakeContext());

        //    var question = fixture.Create<Question>();


        //    // Act
        //    var result = await QuestionsController.Create(question);

        //    // Assert
        //    // Assert
        //}
    }
}
