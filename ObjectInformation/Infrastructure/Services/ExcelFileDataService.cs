using System.Collections.Generic;
using System.IO;
using System.Linq;

using MiniExcelLibs;

using ObjectInformation.Infrastructure.Interfaces;
using ObjectInformation.Models;

namespace ObjectInformation.Infrastructure.Services
{
    public class ExcelFileDataService : IFileData
    {
        #region Fields
        private readonly string _filePath;
        #endregion

        #region Constructors
        public ExcelFileDataService(string filePath)
        {
            _filePath = filePath;
        }
        #endregion

        #region Methods
        public List<ObjectModel> GetData()
        {
            using (FileStream stream = File.OpenRead(_filePath))
            {
                IEnumerable<ObjectModel> data = stream.Query<ObjectModel>();

                return new List<ObjectModel>(data);
            }
        }
        #endregion
    }
}
