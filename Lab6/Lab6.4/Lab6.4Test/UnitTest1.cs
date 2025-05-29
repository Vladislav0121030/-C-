using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6._4;

namespace Lab6._4Test
{

    [TestClass]
    public class EmailValidatorTests
    {
        [TestMethod]
        [DataRow("test@test.com", true)]
        [DataRow("user.name@domain.co.uk", true)]
        [DataRow("firstname.lastname@example.com", true)]
        [DataRow("email@subdomain.domain.com", true)]
        [DataRow("1234567890@example.com", true)]
        [DataRow("email@domain-one.com", true)]
        [DataRow("_______@example.com", true)]
        [DataRow("email@domain.name", true)]
        public void IsValidEmail_ValidEmails_ReturnsTrue(string email, bool expected)
        {
            var result = EmailValidator.IsValidEmail(email);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("plainaddress", false)]
        [DataRow("@missingusername.com", false)]
        [DataRow("username@.com", false)]
        [DataRow(".username@domain.com", false)]
        [DataRow("username@domain..com", false)]
        [DataRow("username@domain.c", false)]
        [DataRow("username@domain..com", false)]
        [DataRow("username@domain_com", false)]
        [DataRow("username@domain:com", false)]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("   ", false)]
        public void IsValidEmail_InvalidEmails_ReturnsFalse(string email, bool expected)
        {
            var result = EmailValidator.IsValidEmail(email);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsValidEmail_WithWhitespace_ReturnsFalse()
        {
            string email = " test@test.com ";
            var result = EmailValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_WithMultipleAtSymbols_ReturnsFalse()
        {
            string email = "test@@test.com";
            var result = EmailValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_WithSpecialCharsInDomain_ReturnsFalse()
        {
            string email = "test@test#.com";
            var result = EmailValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }
    }
}
