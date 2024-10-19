namespace LatestNews.Test.Components.UiFunctionality.Navigation.ViewModels
{
    using LatestNews.Components.UiFunctionality.Navigation.ViewModels;
    using TestUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;

    /// <summary>
    ///     Unit testing of the root view model.
    /// </summary>
    [TestClass]
    public class BaseViewModelTest : BaseTestClass
    {
        /// <summary>
        /// Test viewmodel to test abstract base view model functionality.
        /// </summary>
        private class TestViewModel : BaseViewModel
        {
            public TestViewModel()
            {
            }
        }
        
        private BaseViewModel _viewModel;

        /// <summary>
        ///     Initialization of the modules necessary for the unit test.
        /// </summary>
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            _viewModel = new TestViewModel();
        }

        /// <summary>
        ///     IsBackNavigationEnabled shall return true on get.
        /// </summary>
        [TestMethod]
        public void IsBackNavigationEnabled_ReturnsTrue_OnGet()
        {
            Assert.IsTrue(_viewModel.IsBackNavigationEnabled);
        }

        /// <summary>
        ///     BackNavigationCommand shall close the current view when called.
        /// </summary>
        [TestMethod]
        public async Task BackNavigationCommand_ClosesCurrentView_OnCall()
        {
            //Act
            await _viewModel.BackNavigationCommand.ExecuteAsync(null);

            //Assert
            NavigationServiceMock.Verify(n => n.Close(), Times.Once);
        }


        /// <summary>
        ///     BackNavigationCommand shall NOT close the current view when called and IsBackNavigationEnabled is false.
        /// </summary>
        [TestMethod]
        public async Task BackNavigationCommand_DoesNotCloseCurrentView_IfBackNavigationDisabled()
        {
            //Arrange
            _viewModel.IsBackNavigationEnabled = false;

            //Act
            await _viewModel.BackNavigationCommand.ExecuteAsync(null);

            //Assert
            Assert.IsFalse(_viewModel.BackNavigationCommand.CanExecute(null));
        }

        /// <summary>
        ///     IsBackNavigationEnabled shall raise CanExecutedChanged on BackNavigationCommand.
        /// </summary>
        [TestMethod]
        public void IsBackNavigationEnabled_RaisesCanExecutedChanged_OnSet()
        {
            Assert.IsTrue(_viewModel.IsBackNavigationEnabled);

            //Arrange
            bool raised = false;
            _viewModel.BackNavigationCommand.CanExecuteChanged += (s, e) => raised = true;

            //Act
            _viewModel.IsBackNavigationEnabled = false;

            //Assert
            Assert.IsTrue(raised);
        }

        /// <summary>
        ///     BackNavigationCommand shall always return the same command instance.
        ///     Needed for UI Binding and RaiseCanExecutedChanged.
        /// </summary>
        [TestMethod]
        public void BackNavigationCommand_AlwaysReturnsSameInstance_OnGet()
        {
            var firstReference = _viewModel.BackNavigationCommand;
            var secondReference = _viewModel.BackNavigationCommand;
            Assert.IsTrue(ReferenceEquals(firstReference, secondReference));
        }

   
    }
}