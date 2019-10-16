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

            var loadedData = new Parser.Parser(docpath);
            //var loadedData = ParseDocs(docpath);
            GenerateBinding(loadedData, destpath);
        }


        private static void GenerateBinding(object loadedData, string destpath)
        {
            throw new NotImplementedException();
        }


    }
}
