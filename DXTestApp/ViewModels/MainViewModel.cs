using DevExpress.Xpf.Core;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DXTestApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace DXTestApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //названия переменных в json
        string nameVar1 = "var1";
        string nameVar2 = "var2";

        Models.File jsonObj; //json объект

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        RichEditControl _richEditControl;
        public MainViewModel(RichEditControl richEditControl)
        {
            _richEditControl = richEditControl;
            Variables = new ObservableCollection<Variable>();
            Json = GetStringJson("../../variables.json");
            jsonObj = DeserializeJson(Json);
        }

        public ObservableCollection<Variable> Variables { get; set; }

        //выбранная переменная из comboBox
        private Variable selectedVariable;
        public Variable SelectedVariable
        {
            get { return selectedVariable; }
            set
            {
                selectedVariable = value;
                OnPropertyChanged("SelectedVariable");
            }
        }

        //текст json
        private string json;
        public string Json
        {
            get { return json; }
            set
            {
                json = value;
                OnPropertyChanged("Json");
            }
        }

        //вывод формы для создания переменной
        public ICommand ShowAddVariableForm
        {
            get
            {
                return new CommandDoc((obj) =>
                {
                    AddVariableViewModel a = new AddVariableViewModel();
                    a.Show(this);
                });
            }
        }

        //создание переменной
        public void AddDocVar(string nameVar, string valVar)
        {
            _richEditControl.Document.Variables.Add("DOCVARIABLE " + nameVar, valVar);
            Variables.Add(new Variable("DOCVARIABLE " + nameVar, valVar));
        }


        //добавление поля
        public ICommand AddField
        {
            get
            {
                return new CommandDoc((obj) =>
                {
                    var doc = _richEditControl.Document;
                    DocumentPosition pos = doc.CaretPosition;
                    SubDocument subDoc = pos.BeginUpdateDocument();
                    string name = SelectedVariable.NameVar;
                    subDoc.Fields.Create(pos, SelectedVariable.NameVar);
                    pos.EndUpdateDocument(subDoc);
                });
            }
        }

        //десериализуем json
        private Models.File DeserializeJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<Models.File>(jsonStr);
        }

        //читаем json
        private string GetStringJson(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
   
        //заполнение полей
        public ICommand FillField
        {
            get
            {
                return new CommandDoc((obj) =>
                {
                    int countObj = jsonObj.variables.Length;//кол-во объектов в json

                    Document doc = _richEditControl.Document;
                    FieldCollection field =  _richEditControl.Document.Fields;
                    int countField = field.Count;  //кол-во полей                
                    for (int i = 0; i < countObj; i++)
                    {
                        //добавляем значения переменных из json
                        _richEditControl.Document.Variables.Add("DOCVARIABLE " + nameVar1, jsonObj.variables[i].var1);
                        _richEditControl.Document.Variables.Add("DOCVARIABLE " + nameVar2, jsonObj.variables[i].var2);

                        //заполняем поля
                        for (int j = 0; j < countField; j++)
                        {
                            doc.CalculateDocumentVariable += Document_CalculateDocumentVariable;
                            field[j].Update();
                        }

                        //сохраняем документ
                        int num = i + 1;
                        string path = @"../../Document/file" + num + ".docx";
                        doc.SaveDocument(path, DocumentFormat.OpenXml);
                    }
                    MessageBox.Show("Файлы созданы");
                });
            }
        }

        //обрабочик события для DOCVARIABLE
        private void Document_CalculateDocumentVariable(object sender, CalculateDocumentVariableEventArgs e)
        {
            RichEditControl richEditCon = (RichEditControl)sender;
            richEditCon.CalculateDocumentVariable -= Document_CalculateDocumentVariable;
            var doc = richEditCon.Document.Variables;
            string val = (string)richEditCon.Document.Variables["DOCVARIABLE " + e.VariableName];//значение переменной
            e.Value = val;
            e.Handled = true;
        }
    }
}
