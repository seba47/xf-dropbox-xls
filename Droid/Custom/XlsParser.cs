using System;
using System.Collections.Generic;
using System.IO;
using org.in2bits.MyXls;
using Playground.Droid.Custom;
using Playground.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(XlsParser))]
namespace Playground.Droid.Custom
{
    public class XlsParser: IXlsParser
    {
        public XlsParser()
        {
            
        }

        public object Parse(Stream s)
        {
            XlsDocument doc = new XlsDocument(s);
			org.in2bits.MyXls.Worksheet sheet = doc.Workbook.Worksheets[0];
            List<org.in2bits.MyXls.Row> list = new List<org.in2bits.MyXls.Row>(); 
			if (sheet != null)
			{
				foreach (var row in sheet.Rows)
				{
                    list.Add(row);
				}
			}
			return list;
        }
    }
}
