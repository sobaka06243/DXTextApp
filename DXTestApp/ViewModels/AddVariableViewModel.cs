using DXTestApp.Models;
using DXTestApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DXTestApp.ViewModels
{
    class AddVariableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //значение переменной
        private string _valVar;
        public string ValVar
        {
            get { return _valVar; }
            set
            {
                _valVar = value;
                onPropertyChanged();
            }
        }

        //имя переменной
        private string _nameVar;
        public string NameVar
        {
            get { return _nameVar; }
            set
            {
                _nameVar = value;
                onPropertyChanged();
            }
        }

        AddVariable _addVariable;
        MainViewModel _mainViewModel;

        //добавление переменной
        public ICommand Click_Ok
        {
            get
            {
                return new CommandDoc((obj) =>
                {
                    _mainViewModel.AddDocVar(NameVar, ValVar);
                    _addVariable.Close();
                });
            }
        }

        //отмена добавления переменной
        public ICommand Click_Cancel
        {
            get
            {
                return new CommandDoc((obj) =>
                {
                    _addVariable.Close();
                });
            }
        }

        //вывод формы для создания переменной
        public void Show(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _addVariable = new AddVariable();
            _addVariable.DataContext = this;
            _addVariable.Show();
        }
    }
}
