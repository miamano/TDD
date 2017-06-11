using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidationEngine;


namespace ValidationEngine.Test
{
    [TestFixture]
    public class ValidationTests
    {
       
        [Test]
        public void TrueForValidAddress()
        {
            List<string> validEmailAddresses = new List<string> {"mike@edument.se", "joe@apple.com"};

            var sut = new Validator();

            foreach (var emailInput in validEmailAddresses)
            {
                bool result = sut.ValidateEmailAddress(emailInput);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void FalseForInvalidAddress()
        {
            List<string> invalidEmailAddresses = new List<string> {
                                                   "",
                                                   "Test.com",
                                                   "name@test",
                                                   "name.test@com",
                                                   "Name2015@test.com",
                                                   "name@test2015.com"};

            var sut = new Validator();

            foreach (var emailInput in invalidEmailAddresses)
            {
                bool result = sut.ValidateEmailAddress(emailInput);
                Assert.IsFalse(result);
            }
        }
    }
}

