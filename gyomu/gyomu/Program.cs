using System;
using System.IO;
using System.Xml.Linq;

namespace FileCopyAndCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sourcePath = @"C:\Users\JW162\Desktop\aji-pj\テストデータ\自動生成";
            //string destinationPath = @"C:\Users\JW162\Desktop\aji-pj\テストデータ\アウトプット";

            //// フォルダ内のすべてのファイルをコピーする
            //string[] files = Directory.GetFiles(sourcePath);
            ////foreach (string file in files)
            ////{
            ////    string fileName = Path.GetFileName(file);
            ////    string destinationFile = Path.Combine(destinationPath, fileName);
            ////    File.Copy(file, destinationFile);
            ////}

            //// ファイルを作成する
            //string baseFileName = "meal_";
            //string baseDirectory = Path.GetDirectoryName(destinationPath);
            //int suuji = 20230011;
            //int fileCount = 30;
            //for (int i = 1; i <= fileCount; i++)
            //{
            //    var suujiname = suuji + i;
            //    string newFileName = baseFileName + suujiname.ToString() + ".xml";
            //    string newFilePath = Path.Combine(baseDirectory, newFileName);
            //    File.Copy(files[0], newFilePath);
            //}

            #region csv to xml
            // CSVファイルのパスを指定
            string csvFilePath = @"C:\Users\JW162\Desktop\test2.csv";

            // CSVファイルを読み込む
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // XMLドキュメントを作成する
            XDocument xml = new XDocument(new XElement("doc"));

            // CSVファイルの各行を処理する
            foreach (string csvLine in csvLines)
            {
                // カンマで区切られた各列を取得する
                string[] csvColumns = csvLine.Split(',');
                var tags = csvColumns[5] + "," + csvColumns[6] + "," + csvColumns[7];

                // XML要素を作成して、XMLドキュメントに追加する
                XElement xmlElement = new XElement("meals",
                    new XAttribute("meal_id", csvColumns[0]),
                    new XElement("Meal_Created", csvColumns[1]),
                    new XElement("Menu_Code1", csvColumns[2]),
                    new XElement("Menu_Code2", csvColumns[3]),
                    new XElement("Menu_Code3", csvColumns[4]),
                    new XElement("Tags", tags),
                    new XElement("Clip_Count", csvColumns[8])
                );
                xml.Root.Add(xmlElement);
            }

            // XMLファイルを保存する
            string xmlFilePath = @"C:\Users\JW162\Desktop\aji-pj\テストデータ\自動生成\output.xml";
            xml.Save(xmlFilePath);
            #endregion

            string sourcePath = @"C:\Users\JW162\Desktop\aji-pj\テストデータ\自動生成";
            string destinationPath = @"C:\Users\JW162\Desktop\aji-pj\テストデータ\アウトプット";

            // フォルダ内のすべてのファイルをコピーする
            string[] files = Directory.GetFiles(sourcePath);
            
            // ファイルを作成する
            string baseFileName = "meal_";
            string baseDirectory = Path.GetDirectoryName(destinationPath);
            int suuji = 20230050;
            int fileCount = 2;
            for (int i = 1; i <= fileCount; i++)
            {
                var suujiname = suuji + i;
                string newFileName = baseFileName + suujiname.ToString() + ".xml";
                string newFilePath = Path.Combine(destinationPath, newFileName);
                File.Copy(files[0], newFilePath);
            }
        }
    }
}
