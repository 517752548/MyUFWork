using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using ExcelConverter.Excel.Editor;

namespace BetaFramework
{
    public class GameCodeGen
    {
        public const string GeneratingLbl = "Generating";
        public const string DoneGeneratingLbl = "Done Generating";
        public static void GenClasses(ExcelData[] allSheets)
        {
            for (int i=0; i < allSheets.Length; i++)
            {
                GenClass(allSheets[i].Head[0][0].ToString(), allSheets[i].SheetName, allSheets[i]);
                GenContainerClass(allSheets[i].Head[0][0].ToString(), allSheets[i].SheetName, allSheets[i]);
            }
        }

        static void GenClass(string tKey, string sheetKey, ExcelData sheetData)
        {
            StringBuilder sb = new StringBuilder();
            string className = string.Format(GameCodeGenConstants.DataClassNameFormat, sheetKey);
			string fileName = string.Format(GameCodeGenConstants.ClassFileNameFormat, className);
            LoggerHelper.Log(GeneratingLbl + " " + fileName);

            // Add the auto generated comment at the top of the file
            sb.Append(GameCodeGenConstants.AutoGenMsg);
            sb.Append("\n");

            // Append all the using statements
            sb.Append(GameCodeGenConstants.DataClassHeader);
            sb.Append("\n");

            // Append the class declaration
            sb.AppendFormat(GameCodeGenConstants.ClassDeclarationFormat, className, tKey);
            sb.Append("\n");
            sb.Append("{".PadLeft(1));
            sb.Append("\n");

            // Append all the data variables
            /// 0. Property definitions
            /// 1. Property comments
            /// 2. Property types
            for (int i=0; i < sheetData.DataColumnLen; i++)
            {
                string propertyType = sheetData.Head[0][i].ToString();
                string propertyComments = sheetData.Head[1][i].ToString();
                string propertyName = sheetData.Head[2][i].ToString();

                AppendVariableDeclarations(sb, propertyComments, propertyType, propertyName);
                sb.Append("\n");
            }

            // Append the close class brace
            sb.Append("}".PadLeft(1));
            sb.Append("\n");

            WriteFile(sb, fileName);
            AssetDatabase.Refresh();
        }

        static void GenContainerClass(string tKey, string sheetKey, ExcelData sheetData)
        {
            StringBuilder sb = new StringBuilder();
            string containerClassName = string.Format(GameCodeGenConstants.ContainerDataClassNameFormat, sheetKey);
            string className = string.Format(GameCodeGenConstants.DataClassNameFormat, sheetKey);

            string fileName = string.Format(GameCodeGenConstants.ClassFileNameFormat, containerClassName, tKey);
            Debug.Log(GeneratingLbl + " " + fileName);

            // Add the auto generated comment at the top of the file
            sb.Append(GameCodeGenConstants.AutoGenMsg);
            sb.Append("\n");

            // Append all the using statements
            sb.Append(GameCodeGenConstants.DataClassHeader);
            sb.Append("\n");

            // Append the class declaration
            sb.AppendFormat(GameCodeGenConstants.ContainerClassDeclarationFormat, containerClassName, tKey, className);
            sb.Append("\n");
            sb.Append("{".PadLeft(1));
            sb.Append("\n");

            // Append the close class brace
            sb.Append("}".PadLeft(1));
            sb.Append("\n");

            WriteFile(sb, fileName);
            AssetDatabase.Refresh();
        }


        static void WriteFile(StringBuilder sb, string fileName)
        {
            string fullPath = string.Empty;
            var results = AssetDatabase.FindAssets(Path.GetFileNameWithoutExtension(fileName) + " t:Script");
            if (results != null && results.Length > 0)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(results[0]);
                fullPath = Path.Combine(Environment.CurrentDirectory, assetPath);
            }
            else
            {
                string dir = Application.dataPath + "/" + GameCodeGenConstants.FullRootDir;
                fullPath = Path.Combine(dir, fileName);
            }

            FileUtils.CreateTextFile(fullPath, sb.ToString());
            Debug.Log(DoneGeneratingLbl + " " + fileName);
        }

        static void AppendVariableDeclarations(StringBuilder sb, string comments, string propertyType, string propertyName)
        {
            sb.Append("".PadLeft(GameCodeGenConstants.IndentLevel1));
            sb.AppendFormat(GameCodeGenConstants.VariableComments, comments);
            sb.Append("\n");

            sb.Append("".PadLeft(GameCodeGenConstants.IndentLevel1));
            sb.AppendFormat(GameCodeGenConstants.VariableFormat, propertyType, propertyName);
            sb.Append("\n");
        }


    }
}
