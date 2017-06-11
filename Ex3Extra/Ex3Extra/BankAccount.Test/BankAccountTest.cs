using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace BankAccount.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        private IAuditLogger auditLogger;
        private Bank sut;

        [SetUp]
        public void SetUp()
        {
            auditLogger = Substitute.For<IAuditLogger>(); 
            sut = new Bank(auditLogger); 
        }

        [Test]
        public void CanCreateBankAccount()
        {
            sut.CreateAccount(new Account("123456", "Bucika", 0));

            var account = sut.GetAccount("123456");

            Assert.That(account.Name == "Bucika");
            Assert.That(account.Balance == 0);
            Assert.That(account.Number == "123456");
        }

        [Test]
        public void CanNotCreateDuplicateAccount()
        {
            sut.CreateAccount(new Account("123456", "Bucika", 0));
            Assert.Throws<DuplicateAccount>(() => sut.CreateAccount(new Account("123456", "Bucika", 0)));
        }

        [Test]
        public void WhenCreatingAnAccount_AMessageISWrittingToTheAuditLog()
        {
            sut.CreateAccount(new Account("123456", "Bucika", 0));

            auditLogger.Received().AddMessage(Arg.Is<string>(x => x.Contains("123456") && x.Contains("Bucika")));
        }

        [Test]
        public void WhenCreatingAnValidAccount_OneMessagesAreWrittenToTheAuditLog()
        {
            sut.CreateAccount(new Account("123456", "Bucika", 0));

            //TODO
            auditLogger.Received(1).AddMessage(Arg.Any<string>());
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(new Account("notnumber", "Bucika", 0)));
            auditLogger.Received(2).AddMessage(Arg.Any<string>());
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndError45MessageIsWrittenToAuditLog()
        {
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(new Account("notnumber", "Bucika", 0)));
            auditLogger.Received(2).AddMessage(Arg.Is<string>(x => x.Contains("Warn12") || x.Contains("Error45")));
        }

        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            auditLogger.GetLog().Returns(new List<string>{"Bucika 123456", "Ducika 112233", "Lucika 121212" });

            var logs = sut.GetAuditLog();

            Assert.AreEqual(3, logs.Count);
            Assert.That(logs.Contains("Bucika 123456"));
        }
    }
}
