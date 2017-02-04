using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileSystemWrapper.Common;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Implmentation;
using FileSystemWrapper.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FileSystemWrapper.Test
{
    [TestClass]
    public class FileServiceTests
    {
        private Mock<IFileActionsBroker> _mockFileMediator;
        private Mock<IFileManager> _mockFileManager;
        private Mock<IFileAction> _mockFileAction;

        private FileService _fileService;
        private IList<string> _pathCollection;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mockFileMediator = new Mock<IFileActionsBroker>();
            _mockFileManager = new Mock<IFileManager>();
            _mockFileAction = new Mock<IFileAction>();

            _fileService = new FileService(_mockFileManager.Object, _mockFileMediator.Object);
            _pathCollection = new List<string>
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
            _mockFileMediator.ResetCalls();
            _mockFileManager.ResetCalls();
            _mockFileAction.ResetCalls();
        }
        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _mockFileMediator.VerifyAll();
            _mockFileManager.VerifyAll();
            _mockFileAction.VerifyAll();
        }
        [Test]
        public void ProcessEmptyDirectoryPath_Case1()
        {
            // Arrange
            var path = string.Empty;
            var command = AvailableActions.All;

            _mockFileMediator
                .Setup(q => q.GetCurrentActionType(command))
                .Returns(_mockFileAction.Object);

            _mockFileManager
                .Setup(q => q.GetFileNamesAsync(path, command))
                .Returns(() => Task.FromResult(new List<string>()));

            // Actual
            _fileService.FileProcessAsync(path, command).Wait();

            // Assert
            _mockFileMediator.Verify(q => q.GetCurrentActionType(command), Times.Once, "Must be called once");
            _mockFileManager.Verify(q => q.GetFileNamesAsync(It.IsAny<string>(), command), Times.Once, "Must be called once");
            _mockFileAction.Verify(q => q.Execute(It.IsAny<string>()), Times.Never, "Should not be called");
            _mockFileManager.Verify(q => q.SaveAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never, "Should not be called");
        }

        [Test]
        public void ProcessDirectoryAll_Case4()
        {
            // Arrange
            var command = AvailableActions.All;

            _mockFileMediator
                .Setup(q => q.GetCurrentActionType(command))
                .Returns(_mockFileAction.Object);

            _mockFileManager
                .Setup(q => q.GetFileNamesAsync(It.IsAny<string>(), command))
                .Returns(() => Task.FromResult(_pathCollection.ToList()));

            // Actual
            _fileService.FileProcessAsync(It.IsAny<string>(), command).Wait();

            // Assert
            _mockFileMediator.Verify(q => q.GetCurrentActionType(command), Times.Once, "Must be called once");
            _mockFileManager.Verify(q => q.GetFileNamesAsync(It.IsAny<string>(), command), Times.Once(), "Must be called once");
            _mockFileAction.Verify(q => q.Execute(It.IsAny<string>()), Times.Exactly(_pathCollection.Count), $"Must be called {_pathCollection.Count} times");
            _mockFileManager.Verify(q => q.SaveAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(_pathCollection.Count), $"Must be called {_pathCollection.Count} times");
        }

        [Test]
        public void ProcessDirectoryCpp_Case5()
        {
            // Arrange
            var command = AvailableActions.Cpp;
            var sortedCollection = new List<string>();

            sortedCollection = _pathCollection
                .Where(q => q.Substring(q.Length - 3) == StartupSetting.Instance.AvalibleCommands
                    .FirstOrDefault(x => x.Value == AvailableActions.Cpp).Key).ToList();

            _mockFileMediator
                .Setup(q => q.GetCurrentActionType(command))
                .Returns(_mockFileAction.Object);

            _mockFileManager
                .Setup(q => q.GetFileNamesAsync(It.IsAny<string>(), command))
                .Returns(() => Task.FromResult(sortedCollection));

            // Actual
            _fileService.FileProcessAsync(It.IsAny<string>(), command).Wait();

            // Assert
            _mockFileMediator.Verify(q => q.GetCurrentActionType(command), Times.Once, "Must be called once");
            _mockFileManager.Verify(q => q.GetFileNamesAsync(It.IsAny<string>(), command), Times.Once(), "Must be called once");
            _mockFileAction.Verify(q => q.Execute(It.IsAny<string>()), Times.Exactly(sortedCollection.Count), $"Must be called {sortedCollection.Count} times");
            _mockFileManager.Verify(q => q.SaveAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(sortedCollection.Count), $"Must be called {sortedCollection.Count} times");
        }


        [Test]
        public void PropertyEmptyFileName_Case2()
        {
            // Arrange
            _fileService.ResultFileName = string.Empty;

            // Actual
            var returnedName = _fileService.ResultFileName;
            // Assert
            Assert.That(returnedName, Is.EqualTo(StartupSetting.Instance.MyDocumentsDirectory));
        }

        [Test]
        public void PropertyCustomFileName_Case3()
        {
            // Arrange
            var customFileName = "logfile";
            var expectedFileName = customFileName;

            _fileService.ResultFileName = customFileName;

            // Actual
            var returnedName = _fileService.ResultFileName;
            // Assert
            Assert.That(returnedName, Is.EqualTo(expectedFileName));
        }
    }
}
