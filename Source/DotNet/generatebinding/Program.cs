using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Type = generatebinding.Parser.Type;

namespace generatebinding
{
    class Program
    {
        static void Main(string[] args)
        {
            var docpath = args[0];
            var destpath = args[1];

            var loadedData = new Parser.Parser(docpath);
            //var loadedData = ParseDocs(docpath);
            GenerateBinding(loadedData, destpath);
        }


        private static void GenerateBinding(Parser.Parser loadedData, string destpath)
        {
            destpath = Path.Combine(destpath, "Generated");

            if(Directory.Exists(destpath))
                Directory.Delete(destpath, true);

            Directory.CreateDirectory(destpath);

            foreach (var type in loadedData.Types.Values)
            {
                var file = Path.Combine(destpath, type.FullName.Replace('.', Path.DirectorySeparatorChar) + ".cs");
                
                var folder = Path.GetDirectoryName(file);
                Directory.CreateDirectory(folder);

                GenerateFile(type, file, loadedData);
            }
        }

        private static void GenerateFile(Type type, string file, Parser.Parser loadedData)
        {
            throw new NotImplementedException();
        }
    }
}
