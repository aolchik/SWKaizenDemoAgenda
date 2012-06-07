using DemoAgenda.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Rhino.Mocks;

namespace DemoAgenda.Tests
{

    public class UserDaoStub : IUserDao
    {
        private IUserInfo _userResult = null;
        public IUserInfo UserResult
        {
            get { return _userResult; }
            set { _userResult = value; }
        }

        public void Insert(IUserInfo user)
        {
            user.FirstName = UserResult.FirstName;
            user.Surname = UserResult.Surname;
            user.Login = UserResult.Surname;
            user.Password = UserResult.Password;
            user.IsNew = false;
            user.ID += 1;
        }

        public void Update(IUserInfo user) { }

        public IUserInfo LastInserted { get { return UserResult; } }
    }

    [TestClass()]
    public class UserBCTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        [TestMethod()]		
        public void TestUserBCCanSaveUserNoSOC()
        {
            // Pré condições (contexto)
            IUserInfo user = new UserInfo
                ("João", "Pinto", "jpinto", "senha");
            Assert.IsTrue(user.IsNew);
            Assert.AreEqual(UserInfo.NEW_OBJECT_ID, user.ID);

            UserDaoStub userDaoStub = new UserDaoStub();
            userDaoStub.UserResult = user;

            // Método a ser testado
            UserBC bcUser = new UserBC(userDaoStub);
            bcUser.SaveUser(user);

            // Verificação das pós-condições
            Assert.IsFalse(user.IsNew);
            Assert.IsTrue(user.ID != UserInfo.NEW_OBJECT_ID);
        }

        [TestMethod()]
        public void TestUserBCCanSaveUserWithMocks()
        {
            // Pré condições (contexto) - Arrange
            MockRepository mocks = new MockRepository();
            IUserInfo mockUser = mocks.StrictMock<IUserInfo>();
            IUserDao mockUserDao = mocks.StrictMock<IUserDao>();

            // Expectativas
            Expect.Call(mockUser.IsNew).Return(true);
            Expect.Call(mockUser.Validate()).Return(true);
            Expect.Call(delegate { mockUserDao.Insert(mockUser); });
            mocks.ReplayAll();

            // Método a ser testado - Act
            UserBC bcUser = new UserBC(mockUserDao);
            bcUser.SaveUser(mockUser);

            // Verificação das pós-condições - Assert
            mocks.VerifyAll();
        }


        private bool IsUserInsertedInDatabase(string name, string surname, string user, string password)
        {
            return false;
        }

    
    }

    [TestClass()]
    public class When_saving_an_user
    {
        private MockRepository mocks;

        [TestInitialize]
        public void SetUp()
        {
            mocks = new MockRepository();
        }
        
        [TestMethod()]
        public void Should_validate_user()
        {
            // Arrange
            IUserInfo mockUser = mocks.StrictMock<IUserInfo>();
            IUserDao mockUserDao = mocks.Stub<IUserDao>();
            SetupResult.For(mockUser.IsNew).Return(true);
            Expect.Call(mockUser.Validate()).Return(true);

            // Act
            mocks.ReplayAll();
            UserBC bcUser = new UserBC(mockUserDao);
            bcUser.SaveUser(mockUser);

            // Assert
            mocks.VerifyAll();
        }

        [TestMethod()]
        public void Should_insert_new_user()
        {
            // Arrange
            IUserInfo mockUser = mocks.Stub<IUserInfo>();
            IUserDao mockUserDao = mocks.StrictMock<IUserDao>();
            mockUser.IsNew = true;
            Expect.Call(delegate { mockUserDao.Insert(mockUser); });

            // Act
            mocks.ReplayAll();
            UserBC bcUser = new UserBC(mockUserDao);
            bcUser.SaveUser(mockUser);

            // Assert
            mocks.VerifyAll();
        }

        [TestMethod()]
        public void Should_udpate_existing_user()
        {
            // Arrange
            IUserInfo mockUser = mocks.Stub<IUserInfo>();
            IUserDao mockUserDao = mocks.StrictMock<IUserDao>();
            mockUser.IsNew = false;
            Expect.Call(delegate { mockUserDao.Update(mockUser); });

            // Act
            mocks.ReplayAll();
            UserBC bcUser = new UserBC(mockUserDao);
            bcUser.SaveUser(mockUser);

            // Assert
            mocks.VerifyAll();
        }

    }

}
