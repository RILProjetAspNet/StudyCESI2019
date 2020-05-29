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
    public class SubjectsControllerShould
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


            var subject = fixture.Create<Subject>();
            context.Subjects.Add(subject);          

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task Return_Index_View_With_Subjects_List()
        {
            // Arrange
            var fixture = new Fixture();
            var SubjectsController = new SubjectsController(GetFakeContext());


            // Act
            var result = await SubjectsController.Index();

            // Assert
            Assert.NotNull(result);           
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var Subjects = Assert.IsAssignableFrom<List<Subject>>(viewResult.Model);
        }

        [Fact]
        public async Task Return_Edit_View_With_Subjects_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var SubjectsController = new SubjectsController(context);
            var subject = fixture.Create<Subject>();
            subject.SubjectId = context.Subjects.FirstOrDefault().SubjectId;
            // Act
            var result = await SubjectsController.Edit(subject.SubjectId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);                

        }

        [Fact]
        public async Task Return_Details_View_With_Subjects_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var SubjectsController = new SubjectsController(context);
            var subject = fixture.Create<Subject>();
            subject.SubjectId = context.Subjects.FirstOrDefault().SubjectId;

            // Act
            var result = await SubjectsController.Details(subject.SubjectId);
   
            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Return_Delete_View_With_Subjects_List()
        {
            // Arrange
            var fixture = new Fixture();
            var context = GetFakeContext();
            var SubjectsController = new SubjectsController(context);
            var subject = fixture.Create<Subject>();
            subject.SubjectId = context.Subjects.FirstOrDefault().SubjectId;

            // Act
            var result = await SubjectsController.Delete(subject.SubjectId);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }


        //[Fact]
        //public async Task Return_Create_View_With_Subjects_List()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var mockUser = new Mock<UserManager<User>>();

        //    mockUser.Object.Users = // Users est en lecture seul je n'ai donc pas la main sur mes users et je ne peux donc pas gerer mon create dans le controller voir : _userManager.GetUserId(User);
        //    var SubjectsController = new SubjectsController(GetFakeContext());

        //    var subject = fixture.Create<subject>();


        //    // Act
        //    var result = await SubjectsController.Create(subject);

        //    // Assert
        //    // Assert
        //}
    }
}
