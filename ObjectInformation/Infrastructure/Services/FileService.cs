using System.Collections.Generic;
using ObjectInformation.Infrastructure.Interfaces;
using ObjectInformation.Infrastructure.Types;
using ObjectInformation.Models;

namespace ObjectInformation.Infrastructure.Services
{
    public static class FileService
    {
        public static List<ObjectModel> GetDataFromFile(FileData file)
        {
            IFileData data = file.Extension switch
            {
                ".xls" => new ExcelFileDataService(file.FilePath),
                ".xlsx" => new ExcelFileDataService(file.FilePath),
                ".csv" => new CsvFileDataService(file.FilePath),
                _ => null
            };

            return data.GetData();
        }
    }
}
