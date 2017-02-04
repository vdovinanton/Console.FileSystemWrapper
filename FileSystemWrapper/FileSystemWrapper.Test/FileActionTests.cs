using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common;
using FileSystemWrapper.Logic.Implmentation.FileActions;
using NUnit.Framework;

namespace FileSystemWrapper.Test
{
    [TestFixture]
    public class FileActionTests
    {
        private CppPathShift _cppFiles;
        private PathShift _allFiles;
        private ReverseAFilePath _reversedA;
        private ReverseBFilePath _reversedB;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cppFiles = new CppPathShift();
            _allFiles = new PathShift();
            _reversedA = new ReverseAFilePath();
            _reversedB = new ReverseBFilePath();
        }

        [Test]
        public void ArgumentNullException_Case1()
        {
            string filename = null;

            Assert.Throws<ArgumentNullException>(() => _cppFiles.Execute(filename));
            Assert.Throws<ArgumentNullException>(() => _allFiles.Execute(filename));
            Assert.Throws<ArgumentNullException>(() => _reversedA.Execute(filename));
            Assert.Throws<ArgumentNullException>(() => _reversedB.Execute(filename));
        }

        [Test]
        public void FormatedOutput_Case2()
        {
            var input = "f\\bla\\ra\\t.dat";

            var expectedCpp = input + StartupSetting.Instance.CppFormatEnding;
            var expectedAll = input;
            var expectedReversA = "t.dat\\ra\\bla\\f";
            var expectedReversB = "tad.t\\ar\\alb\\f";

            Assert.That(_cppFiles.Execute(input), Is.EqualTo(expectedCpp), "Its not expected");
            Assert.That(_allFiles.Execute(input), Is.EqualTo(expectedAll), "Its not expected");
            Assert.That(_reversedA.Execute(input), Is.EqualTo(expectedReversA), "Its not expected");
            Assert.That(_reversedB.Execute(input), Is.EqualTo(expectedReversB), "Its not expected");
        }
    }
}
