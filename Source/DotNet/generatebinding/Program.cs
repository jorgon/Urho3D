using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace generatebinding
{
    class Program
    {
        static void Main(string[] args)
        {
            var docpath = args[0];
            var destpath = args[1];

            var loadedData = ParseDocs(docpath);
            GenerateBinding(loadedData, destpath);
        }


        private static List<Doc> ParseDocs(string docpath)
        {
            var ret = new List<Doc>();
            foreach (var file in GetDocXmlFiles(docpath))
            {
                var result = Doc.Parse(file);
                if (result != null)
                    ret.Add(result);
            }

            return ret;
        }

        private static IEnumerable<string> GetDocXmlFiles(string docpath)
        {
            foreach (var file in Directory.GetFiles(docpath))
            {
                if (file.ToLower().EndsWith(".xml"))
                    yield return file;
            }
        }

        private static void GenerateBinding(object loadedData, string destpath)
        {
            throw new NotImplementedException();
        }


    }
}
