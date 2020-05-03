using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LispParser;
using System.IO;


namespace LispParserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /// <summary>
        /// Test Get NextC in the Token Parser.
        /// </summary>
        [TestMethod]
        public void TestNextC()
        {
            FileStream fs = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\lisp.txt", FileMode.Open);
            FileStream output = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\out.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(output);

            TokenParser tokenParser = new TokenParser(fs);
            char c = tokenParser.nextc();
            while (c != '\0')
            {
                sw.WriteLine(c);
                c = tokenParser.nextc();
            }
            fs.Close();
            sw.Close();
        }

        [TestMethod]
        public void TestNextToken()
        {
            FileStream fs = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\lisp.txt", FileMode.Open);
            FileStream output = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\out-token.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(output);
            TokenParserTwo tokenParser = new TokenParserTwo(fs);
            using (tokenParser)
            {
                Token t = tokenParser.nextToken();
                while (t != null)
                {
                    sw.WriteLine(t.TokenValue + "," + t.Type);
                    t = tokenParser.nextToken();
                }
            }
            fs.Close();
            sw.Close();
        }

        /// <summary>
        /// Test Get NextC in the Token Parser.
        /// This is will make output file to 1GB large
        /// </summary>
        [TestMethod]
        public void TestNextCTwo()
        {
            FileStream fs = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\lisp.txt", FileMode.Open);
            FileStream output = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\out.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(output);

            TokenParserTwo tokenParser = new TokenParserTwo(fs);
            char c = tokenParser.nextc();
            while (c != '\0')
            {
                sw.WriteLine(c);
                c = tokenParser.nextc();
            }
            fs.Close();
            sw.Close();
        }

        [TestMethod]
        public void TestDirectoryInfo()
        {
            DirectoryInfo di = new DirectoryInfo("D:\\workspace\\c\\my-lib\\abc.txt");

            Assert.AreEqual("my-lib", di.Parent.Name);
        }

        [TestMethod]
        public void TestFileAllReadTest()
        {
            string s = File.ReadAllText("");
        }
    }
}
