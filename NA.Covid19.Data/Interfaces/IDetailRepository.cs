using NA.Covid19.Domain;
using NA.Covid19.Domain.ApiEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NA.Covid19.Data.Interfaces
{
    public interface IDetailRepository
    {
        void DeleteDetailsByDownloadId(int downloadId);
        List<Detail> GetAllDetails();
        void InsertDetail(Detail detail);
        void InsertMultipleDetails(List<Detail> details);
        Task<List<Country>> GetCountries();
    }
}