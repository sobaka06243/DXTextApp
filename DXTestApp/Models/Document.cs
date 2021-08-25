using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTestApp.Models
{
    class Document
    {
        string Name { get; set; }  //имя файла

        string Text { get; set; }  //текст файла

        public Document(string name, string text)
        {
            Name = name;
            Text = text;
        }

        //создание документа
        public void CreateDocument()
        {
            using (DevExpress.XtraRichEdit.RichEditDocumentServer srv =
                new DevExpress.XtraRichEdit.RichEditDocumentServer())
            {
                DevExpress.XtraRichEdit.API.Native.Document doc = srv.Document;
                doc.AppendText(Text);
                srv.SaveDocument(Name, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            }
        }
    }
}
