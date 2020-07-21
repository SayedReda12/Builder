using Builder.Common.ApplicationServices;
using Builder.Common.DependencyInjection;
using Builder.Domain.Dtos.Form;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Application.Form
{
    public interface IFormAppService : ITransientDependency
    {
        Task<ApplicationServiceOutput> GetAllAsync();
        Task<ApplicationServiceOutput> GetAsync(Guid id);
    }
}
