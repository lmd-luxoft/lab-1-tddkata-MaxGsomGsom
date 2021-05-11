// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        private StringCalc calc;

        [SetUp]
        public void SetUp()
        {
            calc = new StringCalc();
        }

        [Test(Description = "Should calculate two numbers")]
        [TestCase("", 0)]
        [TestCase("  ", 0)]
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("    1   ", 1)]
        [TestCase("0,0", 0)]
        [TestCase("1,2", 3)]
        [TestCase("1 , 2", 3)]
        public void ShouldCalculateTwoNumbers(string input, int expected)
        {
            int result = calc.Sum(input);
            Assert.AreEqual(expected, result);
        }

        [Test(Description = "Should return minus one on invalid input")]
        [TestCase(null)]
        [TestCase("-1")]
        [TestCase("-")]
        [TestCase("err")]
        [TestCase("1,err")]
        [TestCase("1,1,1")]
        [TestCase("@,1")]
        [TestCase("1,-1")]
        [TestCase("-1,1")]
        [TestCase("-1,-1")]
        [TestCase("1.1")]
        [TestCase("1:1")]
        [TestCase("1,,1")]
        [TestCase("1;1")]
        public void ShouldReturnMinusOneOnInvalidInput(string input)
        {
            int result = calc.Sum(input);
            Assert.AreEqual(-1, result);
        }
    }
}
