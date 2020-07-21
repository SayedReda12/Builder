
using Builder.Common.ApplicationServices;
using Builder.Common.EntityFromework;
using Builder.Domain.Dtos.Form;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Application.Form
{
    public class FormAppService : BaseService, IFormAppService
    {
        private readonly IRepository<Entities.Form, Guid> _formRepository;

        public FormAppService(IRepository<Entities.Form, Guid> formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<ApplicationServiceOutput> GetAllAsync()
        {
            var forms = await _formRepository.GetAllAsync();

            var jsonForms = forms.Select(a=>a.JsonForm);

            return SuccessServiceOutput( JsonConvert.DeserializeObject<IEnumerable<FormDto>>(JsonConvert.SerializeObject(jsonForms)));
        }

        public async Task<ApplicationServiceOutput> GetAsync(Guid id)
        {
            var form = await _formRepository.GetAsync(a => a.Id == id);

            var jsonForm = form.JsonForm;

            return SuccessServiceOutput( JsonConvert.DeserializeObject<FormDto>(JsonConvert.SerializeObject(jsonForm)));

        }
    }
}
