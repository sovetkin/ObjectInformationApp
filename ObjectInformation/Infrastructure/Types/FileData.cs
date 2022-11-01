namespace ObjectInformation.Infrastructure.Types
{
    public record FileData
    {
        #region Constructors
        public FileData()
        {

        }

        public FileData(string filePath, string fileName, string extension)
        {
            FilePath = filePath;
            FileName = fileName;
            Extension = extension;
        }
        #endregion

        #region Properties
        public string FilePath { get; init; }
        public string FileName { get; init; }
        public string Extension { get; init; }
        #endregion
    }
}
