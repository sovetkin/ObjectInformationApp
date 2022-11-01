using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using ObjectInformation.Infrastructure.Commands;
using ObjectInformation.Infrastructure.Services;
using ObjectInformation.Infrastructure.Types;
using ObjectInformation.Models;

namespace ObjectInformation.ViewModels
{
    public class MainViewViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<ObjectModel> _data;
        private List<ItemInfo> _currentItemData;
        private ObjectModel _selectedObject;
        private FileData _fileInfo;
        private ICommand _loadCommand;
        private RectangleInfo _rectangleData;
        private double _canvasWidth;
        private double _canvasHeight;
        #endregion

        #region Properties
        public ICommand LoadCommand => _loadCommand ??= new LoadCommand(this);

        public FileData FileInfo
        {
            get => _fileInfo;
            set
            {
                _fileInfo = value;

                Data = new ObservableCollection<ObjectModel>(FileService.GetDataFromFile(_fileInfo));
                OnPropertyChanged(nameof(FileInfo));
            }
        }

        public ObservableCollection<ObjectModel> Data
        {
            get => _data;
            set
            {
                if (value == _data) return;

                _data = value;
                OnPropertyChanged(nameof(Data));
                OnPropertyChanged(nameof(SelectedObject));
            }
        }

        public ObjectModel SelectedObject
        {
            get => _selectedObject;
            set
            {
                if (value == _selectedObject) return;

                _selectedObject = value;
                CurrentItemData = GetMetaFromCurrentType(_selectedObject);
                if (_selectedObject is not null)
                    RectangleData = ConvertRectangleInfo(_selectedObject);
                OnPropertyChanged(nameof(SelectedObject));
            }
        }

        public List<ItemInfo> CurrentItemData
        {
            get => _currentItemData;
            set
            {
                if (value == _currentItemData) return;

                _currentItemData = value;
                OnPropertyChanged(nameof(CurrentItemData));
            }
        }

        public RectangleInfo RectangleData
        {
            get => _rectangleData;
            set
            {
                if (value == _rectangleData) return;

                _rectangleData = value;
                OnPropertyChanged(nameof(RectangleData));
            }
        }

        public double CanvasWidth
        {
            get => _canvasWidth;
            set
            {
                _canvasWidth = value;
                if (_selectedObject is not null)
                    RectangleData = ConvertRectangleInfo(_selectedObject);
                OnPropertyChanged(nameof(CanvasWidth));
            }
        }

        public double CanvasHeight
        {
            get => _canvasHeight;
            set
            {
                _canvasHeight = value;
                if (_selectedObject is not null)
                    RectangleData = ConvertRectangleInfo(_selectedObject);
                OnPropertyChanged(nameof(CanvasHeight));
            }
        }

        private double RatioX => (_canvasWidth == 0 ? 213 : _canvasWidth) / 20;
        private double RatioY => (_canvasHeight == 0 ? 76 : _canvasHeight) / 12;
        #endregion

        #region Methods
        public List<ItemInfo> GetMetaFromCurrentType(ObjectModel item)
        {
            return item?.GetType()
                       .GetProperties()
                       .Select(p =>
                             new ItemInfo()
                             {
                                 Name = p.Name + ":",
                                 Value = p.GetValue(item)
                             }).ToList();
        }

        private RectangleInfo ConvertRectangleInfo(ObjectModel obj)
        {
            double x = obj.Distance * RatioX;
            double y = (_canvasHeight == 0 ? 76 : _canvasHeight) - obj.Angle * RatioY;
            double x2 = obj.Width == 0 ? 1 : obj.Width * RatioX;
            double y2 = obj.Heigth == 0 ? 1 : obj.Heigth * RatioY;

            return new RectangleInfo()
            {
                X1 = x,
                Y1 = Math.Abs(y2 - y),
                X2 = x2,
                Y2 = y2
            };
        } 
        #endregion
    }
}
