using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common;
using FileSystemWrapper.Logic.Implmentation;
using FileSystemWrapper.Logic.Interfaces;
using Moq;
using NUnit.Framework;

namespace FileSystemWrapper.Test
{
    [TestFixture]
    public class FileManagerTests
    {
        private Mock<IFileManager> _mockFileManager;
        private FileManager _fileManager;
        private IList<string> _contentCollection;
        private string _fileName;
        private string _currentPath;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mockFileManager = new Mock<IFileManager>();

            _fileManager = new FileManager();
            _fileName = StartupSetting.Instance.DefaultFileName;
            _currentPath = $"{StartupSetting.Instance.MyDocumentsDirectory}\\{_fileName}";

            _contentCollection = new List<string>
            {
                "d:/demo/note.txt",
                "d:/demo/about.html",
                "d:/demo/script.cpp",
                "d:/demo/lids/script.cpp"
            };
        }

        [SetUp]
        public void SetUp()
        {
            _mockFileManager.ResetCalls();
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(_currentPath)) File.Delete(_currentPath);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _mockFileManager.VerifyAll();
        }

        [Test]
        public void CorrectCalledCount_Case1()
        {
            // Arrange
            foreach (var content in _contentCollection)
            {
                _mockFileManager.Object.SaveAsync(It.IsAny<string>(), content).Wait();
            }

            // Assert
            _mockFileManager.Verify(q => q.SaveAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(_contentCollection.Count), $"Must be called {_contentCollection.Count} times");
        }

        [Test]
        public void ContentResultFile_Case3()
        {
            // Arrange
            foreach (var content in _contentCollection)
            {
                _fileManager.SaveAsync(_fileName, content).Wait();
            }

            var actual = File.ReadLines(_currentPath).ToList();

            Assert.That(_contentCollection, Is.EqualTo(actual));
        }

        [Test]
        public void CreateResultFile_Case2()
        {
            // Assert
            foreach (var content in _contentCollection)
            {
                _fileManager.SaveAsync(_fileName, content).Wait();
            }

            Assert.IsTrue(File.Exists(_currentPath));
        }
    }
}
