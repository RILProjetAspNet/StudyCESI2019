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
using System.Threading;

namespace StudyCESI.UnitTests
{
    public class ExamsControllerShould
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


            var exam = fixture.Create<Exam>();
            context.Exams.Add(exam);

            context.SaveChanges();
            return context;
        }

        private static UserManager<User> GetMockedUserManager()
        {
            var fixture = new Fixture();
            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123",
                    Role ="Enseignant"
                });
            var userManager = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);
            return userManager;
        }

       // ne peut pas etre tester car on utiliser User claims dans index pour filtrer par role 
        public async Task Return_Index_View_With_Exams_List()
        {
            // Arrange
            var fixture = new Fixture();
            var ExamsController = new ExamsController(GetFakeContext(), GetMockedUserManager());


            // Act
            var result = await ExamsController.Index();

            // Assert
            Assert.NotNull(result);           
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var Exams = Assert.IsAssignableFrom<List<Exam>>(viewResult.Model);
        }

        [Fact]
        public async Task Return_Edit_View_With_Exams_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var ExamsController = new ExamsController(context, GetMockedUserManager());
            var exam = fixture.Create<Exam>();
            exam.ExamId = context.Exams.FirstOrDefault().ExamId;
            // Act
            var result = await ExamsController.Edit(exam.ExamId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);

        }

        [Fact]
        public async Task Return_Details_View_With_Exams_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var ExamsController = new ExamsController(context, GetMockedUserManager());
            var exam = fixture.Create<Exam>();
            exam.ExamId = context.Exams.FirstOrDefault().ExamId;

            // Act
            var result = await ExamsController.Details(exam.ExamId);
   
            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Return_Delete_View_With_Exams_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var ExamsController = new ExamsController(context, GetMockedUserManager());
            var exam = fixture.Create<Exam>();
            exam.ExamId = context.Exams.FirstOrDefault().ExamId;

            // Act
            var result = await ExamsController.Delete(exam.ExamId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }


        //[Fact]
        //public async Task Return_Create_View_With_Exams_List()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var mockUser = new Mock<UserManager<User>>();

        //    mockUser.Object.Users = // Users est en lecture seul je n'ai donc pas la main sur mes users et je ne peux donc pas gerer mon create dans le controller voir : _userManager.GetUserId(User);
        //    var ExamsController = new ExamsController(GetFakeContext());

        //    var exam = fixture.Create<exam>();


        //    // Act
        //    var result = await ExamsController.Create(exam);

        //    // Assert
        //    // Assert
        //}
    }
}
