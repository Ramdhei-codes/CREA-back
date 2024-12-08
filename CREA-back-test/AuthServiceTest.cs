using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CREA_back_test
{
    public class AuthServiceTest
    {
        private AuthService _authService;

        [SetUp]
        public void SetUp()
        {
            _authService = new AuthService();
        }

        [Test]
        public void ValidCredentialsTest()
        {
            bool result = _authService.ValidateUser("administrador.crea@ucaldas.edu.co", "administrador");

            Assert.That(result, Is.True);
        }

        [Test]
        public void InvalidEmailTest()
        {
            bool result = _authService.ValidateUser("administrador.crea@ucaldas.edu", "administrador");

            Assert.That(result, Is.False);
        }

        [Test]
        public void InvalidPasswordTest()
        {
            bool result = _authService.ValidateUser("administrador.crea@ucaldas.edu.co", "administradorrrrr");

            Assert.That(result, Is.False);
        }
    }
}
