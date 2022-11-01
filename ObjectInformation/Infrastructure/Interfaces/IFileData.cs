using System.Collections.Generic;

using ObjectInformation.Models;

namespace ObjectInformation.Infrastructure.Interfaces
{
    public interface IFileData
    {
        List<ObjectModel> GetData();
    }
}