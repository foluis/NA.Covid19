using NA.Covid19.Domain;
using System.Collections.Generic;

namespace NA.Covid19.Data.Interfaces
{
    public interface IDownloadRepository
    {
        void DeleteDownloadByFileName(string fileName);
        void DeleteDownloadCascadingByFileName(string fileName);
        List<Download> GetAllDownloads();
        Download GetDownloadByFileName(string fileName);
        void InsertDownload(Download download);
        void InsertFullDownload(Download download, List<Detail> details);
    }
}