using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

using ObjectInformation.Infrastructure.Types;
using ObjectInformation.ViewModels;

namespace ObjectInformation.Infrastructure.Commands
{
    public class LoadCommand: BaseCommand
    {
        #region Fields
        private MainViewViewModel _viewModel;
        #endregion

        #region Constructors
        public LoadCommand(MainViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        #endregion

        #region Methods
        public override void Execute(object parameter)
        {
            OpenFileDialog fileDialog = new()
            {
                InitialDirectory = Directory.GetCurrentDirectory() + "\\Data",
                Filter = "Excel files (*.xls, *.xlsx, *.csv)|*.xls;*.xlsx;*.csv",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == true)
                _viewModel.FileInfo = new FileData()
                {
                    FilePath = fileDialog.FileName,
                    FileName = fileDialog.SafeFileName,
                    Extension = Path.GetExtension(fileDialog.FileName)
                };
        } 
        #endregion
    }
}
