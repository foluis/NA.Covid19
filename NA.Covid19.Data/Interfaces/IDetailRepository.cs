using NA.Covid19.Domain;
using System.Collections.Generic;

namespace NA.Covid19.Data.Interfaces
{
    public interface IDetailRepository
    {
        void DeleteDetailsByDownloadId(int downloadId);
        List<Detail> GetAllDetails();
        void InsertDetail(Detail detail);
        void InsertMultipleDetails(List<Detail> details);
    }
}