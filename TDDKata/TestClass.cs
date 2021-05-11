// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Text;
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
        [TestCase("1\n2", 3)]
        [TestCase("1\n2\n3", 6)]
        [TestCase("1, 2,3", 6)]
        [TestCase("1,2,3 \n 4", 10)]
        [TestCase("1,,3", 4)]
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
        [TestCase("@,1")]
        [TestCase("1,-1")]
        [TestCase("-1,1")]
        [TestCase("-1,-1")]
        [TestCase("1.1")]
        [TestCase("1:1")]
        [TestCase("1;1")]
        [TestCase("1,1,-1")]
        [TestCase("1,1;1")]

        public void ShouldReturnMinusOneOnInvalidInput(string input)
        {
            int result = calc.Sum(input);
            Assert.AreEqual(-1, result);
        }

        [Test(Description = "Should calculate sum of numbers")]
        [TestCase('\n', 50)]
        [TestCase(',', 100)]
        public void ShouldCalculateSumOfNumbers(char divider, int count)
        {
            //Arrange
            int expected = 0;
            var input = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                expected += i;
                input.Append(i);
                input.Append(divider);
            }

            //Act
            int result = calc.Sum(input.ToString());

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test(Description = "Should not calculate sum of 100 numbers if last is incorrect")]
        [TestCase("-1")]
        [TestCase("1;")]
        [TestCase("@")]
        public void ShouldNotCalculateSumOfNumbers(string incorrectNumber)
        {
            //Arrange
            var input = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                input.Append(i);
                input.Append(',');
            }
            input.Append(incorrectNumber);

            //Act
            int result = calc.Sum(input.ToString());

            //Assert
            Assert.AreEqual(-1, result);
        }

        [Test(Description = "Should calculate sum if dividers defined in input")]
        [TestCase("//\n\n1\n2", 3)]
        [TestCase("//@\n2@3@4", 9)]
        [TestCase("///\n1/1", 2)]
        public void ShouldCalculateIfDividersDefinedInInput(string input, int expected)
        {
            int result = calc.Sum(input);
            Assert.AreEqual(expected, result);
        }

        [Test(Description = "Should not calculate sum if input with dividers has incorrect format")]
        [TestCase("//ab\n1ab2")]
        [TestCase("//\n23")]
        [TestCase("//;\n5,6")]
        [TestCase("/;\n1;1")]
        [TestCase(";\n1;1")]
        [TestCase("\\\\;\n1;1")]
        [TestCase("//0\n202")]
        [TestCase("//9\n292")]
        public void ShouldCalculateIfDividersDefinedInInput(string input)
        {
            int result = calc.Sum(input);
            Assert.AreEqual(-1, result);
        }
    }
}
