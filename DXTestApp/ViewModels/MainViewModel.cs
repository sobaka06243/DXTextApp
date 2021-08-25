using DevExpress.Xpf.Core;
using DevExpress.Xpf.RichEdit;
using DXTestApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DXTestApp.ViewModels
{
    public class MainViewModel : ThemedWindow
    {
        RichEditControl _richEditControl;
        public MainViewModel(RichEditControl richEditControl)
        {
            _richEditControl = richEditControl;
            CreateFiles(@"../../files.json");
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
            _richEditControl.Document.Variables.Add(nameVar, valVar);
            TestDocVar();
        }

        //тест для проверки переменных
        private void TestDocVar()
        {
            IEnumerator<string> collect = _richEditControl.Document.Variables.Names.GetEnumerator();
            string res = "";
            while (collect.MoveNext())
            {
                string name = collect.Current; //имя переменной
                string val = (string)_richEditControl.Document.Variables[name]; //значение переменной
                res += name + " - " + val + "\n";
            }
            MessageBox.Show(res);
        }

        //создание файлов из json
        private void CreateFiles(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<File>(json);
            int len = obj.files.Length;
            for (int i = 0; i < len; i++)
            {
                Models.Document doc = new Models.Document(obj.files[i].name, obj.files[i].text);
                doc.CreateDocument();
            }
        }
    }
}
