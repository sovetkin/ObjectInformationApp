using System.Collections.Generic;

using ObjectInformation.Infrastructure.Interfaces;
using ObjectInformation.Models;

using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace ObjectInformation.Infrastructure.Services
{
    public class CsvFileDataService : IFileData
    {
        #region Fields
        private readonly string _filePath;
        #endregion

        #region Constructors
        public CsvFileDataService(string filePath)
        {
            _filePath = filePath;
        }
        #endregion

        #region Methods
        public List<ObjectModel> GetData()
        {
            var config = new CsvConfiguration(CultureInfo.CreateSpecificCulture("ru-Ru"))
            {
                Delimiter = ";"
            };

            using (var fileReader = new StreamReader(_filePath))
            {
                using (var csvReader = new CsvReader(fileReader, config))
                {
                    IEnumerable<ObjectModel> data = csvReader.GetRecords<ObjectModel>();

                    return new List<ObjectModel>(data);
                }
            }
        }
        #endregion
    }
}
