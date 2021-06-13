using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Messaging.Core.Models;
using Messaging.Core.Services;

namespace IFM_Tests
{
    public class RabbitServiceTests
    {
        private RabbitService<DefaultRabbitPublisher, DefaultRabbitConsumer> _sut;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}