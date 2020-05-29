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
    public class TypeQuestionsControllerShould
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


            var typeQuestion = fixture.Create<TypeQuestion>();
            context.TypeQuestions.Add(typeQuestion);          

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task Return_Index_View_With_TypeQuestions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var TypeQuestionsController = new TypeQuestionsController(GetFakeContext());


            // Act
            var result = await TypeQuestionsController.Index();

            // Assert
            Assert.NotNull(result);           
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var TypeQuestions = Assert.IsAssignableFrom<List<TypeQuestion>>(viewResult.Model);
        }

        [Fact]
        public async Task Return_Edit_View_With_TypeQuestions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var TypeQuestionsController = new TypeQuestionsController(context);
            var typeQuestion = fixture.Create<TypeQuestion>();
            typeQuestion.TypeQuestionId = context.TypeQuestions.FirstOrDefault().TypeQuestionId;
            // Act
            var result = await TypeQuestionsController.Edit(typeQuestion.TypeQuestionId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);                

        }

        [Fact]
        public async Task Return_Details_View_With_TypeQuestions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var TypeQuestionsController = new TypeQuestionsController(context);
            var typeQuestion = fixture.Create<TypeQuestion>();
            typeQuestion.TypeQuestionId = context.TypeQuestions.FirstOrDefault().TypeQuestionId;

            // Act
            var result = await TypeQuestionsController.Details(typeQuestion.TypeQuestionId);
   
            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Return_Delete_View_With_TypeQuestions_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var TypeQuestionsController = new TypeQuestionsController(context);
            var typeQuestion = fixture.Create<TypeQuestion>();
            typeQuestion.TypeQuestionId = context.TypeQuestions.FirstOrDefault().TypeQuestionId;

            // Act
            var result = await TypeQuestionsController.Delete(typeQuestion.TypeQuestionId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }


        //[Fact]
        //public async Task Return_Create_View_With_TypeQuestions_List()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var mockUser = new Mock<UserManager<User>>();

        //    mockUser.Object.Users = // Users est en lecture seul je n'ai donc pas la main sur mes users et je ne peux donc pas gerer mon create dans le controller voir : _userManager.GetUserId(User);
        //    var TypeQuestionsController = new TypeQuestionsController(GetFakeContext());

        //    var typeQuestion = fixture.Create<typeQuestion>();


        //    // Act
        //    var result = await TypeQuestionsController.Create(typeQuestion);

        //    // Assert
        //    // Assert
        //}
    }
}
