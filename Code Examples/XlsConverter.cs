
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace nvoid.Documents
{
    public class XlsConverter<T> : EntityDocument<T>
    {

        public System.Drawing.Color HeaderColor { get; set; }

        public XlsConverter() : base()
        {
            HeaderColor = System.Drawing.Color.CadetBlue;
        }




        public static void ConvertJson(object jsonData, string newFile, string title)
        {
            Type objType = jsonData.GetType();
            bool isObject = objType == typeof(JObject);
            bool isArray = objType == typeof(JArray);
            if (!isObject && !isArray)
            {
                throw new InvalidOperationException("Only JSON objects|arrays can be converted to XLS. Please make sure that your string is an object|array.");
            }

            using (ExcelPackage xl = new ExcelPackage(new FileInfo(newFile)))
            {
                // get handle to the existing worksheet
                ExcelWorksheet worksheet = xl.Workbook.Worksheets.Add("data");
                int startingRow = 1;
                //Write header
                if (isObject)
                {
                    JObject json = jsonData as JObject;
                    List<JProperty> columnKeys = json.Properties().ToList();
                    for (int i = startingRow; i <= columnKeys.Count() - 1; i++)
                    {
                        JProperty prop = columnKeys[i];
                        worksheet.Cells[startingRow, i + 1].Value = prop.Name;
                        worksheet.Cells[startingRow + 1, i + 1].Value = prop.Value;
                    }
                }
                if (isArray)
                {
                    List<string> columns = new List<string>();
                    int iRow = startingRow + 1;
                    foreach (object jsonItem in jsonData as JArray)
                    {
                        if (jsonItem.GetType() != typeof(JObject))
                        {
                            continue;
                        }
                        List<JProperty> jProps = (jsonItem as JObject).Properties().ToList();

                        for (int iProp = 0; iProp <= jProps.Count - 1; iProp++)
                        {
                            JProperty jp = jProps[iProp];
                            int cellIndex = iProp;
                            if (columns.Contains(jp.Name))
                            {
                                cellIndex = columns.IndexOf(jp.Name);
                            }
                            worksheet.Cells[startingRow, cellIndex + 1].Value = jp.Name;
                            worksheet.Cells[iRow, cellIndex + 1].Value = jp.Value.ToString();
                        }
                        iRow += 1;
                        dynamic jsonItem2 = jsonItem;
                    }
                }
                ExcelWorkbook workbook = xl.Workbook;
                SetMiscInfo(ref workbook, title, "Netlyt", "Netlyt", "Netlyt");
                // save the new spreadsheet
                xl.Save();
            }
        }

        /// <summary>
        /// Converts a data collection to an xlsx file
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="newFile">The filename to save the data as.</param>
        /// <param name="title">The title of the document.</param>
        /// <returns></returns>
        public bool Convert(IEnumerable<T> data, string newFile, string title)
        {
            return Convert(data.ToArray(), newFile, title);
        }
        public bool Convert(T[] data, string newFile, string title)
        {
            try
            {
                FileInfo file = new FileInfo(newFile);
                if (file.Exists)
                {
                    file.Delete();
                }
                using (ExcelPackage xl = new ExcelPackage(new FileInfo(newFile)))
                {
                    ExcelWorksheet worksheet = xl.Workbook.Worksheets.Add("data");

                    dynamic startingRow = 2;
                    dynamic includeHeader = true;
                    for (int iItem = 0; iItem <= data.Length - 1; iItem++)
                    {
                        T item = data[iItem];

                        SetColumnInfo(ref worksheet, item, includeHeader, iItem + startingRow);
                        includeHeader = false;
                    }

                    ExcelWorkbook workbook = xl.Workbook;
                    SetMiscInfo(ref workbook, title, "Netlyt", "Netlyt", "Netlyt");
                    xl.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Convert(T data, string newFile, string title)
        {
            try
            {
                using (ExcelPackage xl = new ExcelPackage(new FileInfo(newFile)))
                {
                    ExcelWorksheet worksheet = xl.Workbook.Worksheets.Add("data");

                    Int32 startingRow = 2;
                    bool includeHeader = true;
                    SetColumnInfo(ref worksheet, data, includeHeader, startingRow);

                    ExcelWorkbook workbook = xl.Workbook;
                    SetMiscInfo(ref workbook, title, "Netlyt", "Netlyt", "Netlyt");
                    xl.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void SetColumnInfo(ref ExcelWorksheet worksheet, T data, bool includeHeader = true, int startingRow = 1)
        {
            List<string> columns = Members.Keys.ToList();


            for (Int32 iCol = 0; iCol <= columns.Count - 1; iCol++)
            {
                string column = columns[iCol];
                object columnValue = Members[column].DynamicInvoke(data);

                if (includeHeader)
                {
                    worksheet.Cells[1, iCol + 1].Value = column;

                    worksheet.Cells[1, iCol + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, iCol + 1].Style.Fill.BackgroundColor.SetColor(HeaderColor);
                    worksheet.Cells[1, iCol + 1].Style.Font.Bold = true;
                }
                worksheet.Cells[startingRow, iCol + 1].Value = string.IsNullOrEmpty((string)columnValue) ? "" : columnValue.ToString();
            }


        }

        private static void SetMiscInfo(ref ExcelWorkbook xl, string title, string keywords, string category, string company)
        {
            xl.Properties.Title = title;
            xl.Properties.Keywords = keywords;
            xl.Properties.Category = category;
            // set some extended property values
            xl.Properties.Company = company;
        }


    }
} 