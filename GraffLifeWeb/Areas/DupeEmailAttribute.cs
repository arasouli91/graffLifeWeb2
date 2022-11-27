using GraffLifeWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GraffLifeWeb.Areas
{
    public class DupeEmailAttribute: ValidationAttribute
    {
        private IServiceProvider serviceProvider;

        public DupeEmailAttribute()
        {
            serviceProvider = AppDependencyResolver.Current.GetService<IServiceProvider>();
        }

        public override bool IsValid(object value)
        {
            // Check Email  -- Only valid emails are allowed to this point, so there is no injection risk
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<ValidationService>();

                return service.ValidateEmail(value.ToString());
            } 
        }
    }


    public class AppDependencyResolver
    {
        private static AppDependencyResolver _resolver;

        public static AppDependencyResolver Current
        {
            get
            {
                if (_resolver == null)
                    throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
                return _resolver;
            }
        }

        public static void Init(IServiceProvider services)
        {
            _resolver = new AppDependencyResolver(services);
        }

        private readonly IServiceProvider _serviceProvider;

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        private AppDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
