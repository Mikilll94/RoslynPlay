﻿using OfficeOpenXml;
using System.IO;
using System.Text;

namespace RoslynPlay
{
    class ExcelWriter
    {
        private FileInfo _file;

        public ExcelWriter(string file)
        {
            _file = new FileInfo(file);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void Write(CommentStore commentStore, ClassStore classStore)
        {
            using (ExcelPackage package = new ExcelPackage(_file))
            {
                new CommentsWorksheet(package, commentStore).Create("Comments");
                new ClassesWorksheet(package, commentStore, classStore).Create("Classes");
                new RankingWorksheet(package, classStore).Create("Ranking");
                new SummaryWorksheet(package, commentStore).Create("Summary");

                package.Save();
            }
        }
    }
}