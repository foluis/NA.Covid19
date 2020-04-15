using NA.Covid19.Domain.ApiEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.Covid19.Web.Services
{
    public interface IDetailService
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
