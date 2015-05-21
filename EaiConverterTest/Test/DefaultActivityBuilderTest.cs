﻿using System;
using NUnit.Framework;
using EaiConverter.Mapper;
using EaiConverter.Test.Utils;

namespace EaiConverterTest
{
    [TestFixture]
    public class DefaultActivityBuilderTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_Log_Activity_Start()
        {
            var logCode = DefaultActivityBuilder.LogActivity("test Activity");
            var generatedCode = TestCodeGeneratorUtils.GenerateCode(logCode);
            Assert.AreEqual("this.logger.Info(\"Start Activity: test Activity\");\n", generatedCode);
        }
    }
}

