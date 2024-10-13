namespace LatestNews.Test.TestUtils
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections;
    using LatestNews.Components.UiFunctionality.Navigation;
    using LatestNews.Components.PlatformUtils;

    
    /// <summary>
    ///     The base test class which resolves the needed singletons for the other test classes.
    /// </summary>
    /// Note: RUN the test in terminal dotnet test -l "console;verbosity=normal"
    public class BaseTestClass
    {
        /// <summary>
        ///     The mock of the navigation service.
        /// </summary>
        protected Mock<INavigationService> NavigationServiceMock { get; private set; }

        /// <summary>
        ///     The service provider.
        /// </summary>
        protected ServiceProviderMockClass ServiceProviderMock { get; private set; }

        /// <summary>
        ///     Setup of the test class.
        /// </summary>
        [TestInitialize]
        public virtual void Initialize()
        {
            NavigationServiceMock = new Mock<INavigationService>();
           
            ServiceProviderMock = new ServiceProviderMockClass();

            ServiceProviderMock.Register(NavigationServiceMock.Object);
            
            ServiceHelper.Initialize(ServiceProviderMock);
        }

        protected internal class ServiceProviderMockClass : IServiceProvider, IEnumerable<object>
        {
            private readonly Dictionary<Type, object> _services = new();
            public object GetService(Type serviceType)
            {
                if (_services.TryGetValue(serviceType, out object instance))
                {
                    return instance;
                }
                var mockType = typeof(Mock);
                var mockFunction = mockType.GetMethods().First(method => method.Name == nameof(Mock.Of) && method.GetParameters().Length == 0);
                return mockFunction.MakeGenericMethod(serviceType).Invoke(null, Array.Empty<object>());
            }

            public void Add<T>(T instance) => Register(instance);

            public void Register<T>(T instance)
            {
                _services[typeof(T)] = instance;
            }

            public IEnumerator<object> GetEnumerator() => _services.Values.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}