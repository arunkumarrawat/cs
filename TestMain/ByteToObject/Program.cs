using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ByteToObject
{
    //@example: translate Byte to Object
    public class Message
    {
        byte[] messageData;
        public Message(byte[] bytes)
        {
            messageData = bytes;
        }

        public int FC
        {
            get { return messageData[1]; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[5] { 1, 2, 3, 4, 5};
            Message message = new Message(bytes);
            Console.WriteLine(message.FC);

            byte[] data = new byte[]{14,13,0,11,0,1,87,0,76,34,37,30,9,5,14,3,0,11,0,1,11,0,76,36,44,30,9,5,18,13,0,11,0,3,0,21,205,39,15,3,0,65,3,30,9,5,18,13,0,11,0,3,0,13,205,39,17,3,0,65,16,30,9,5,14,13,0,11,0,1,87,0,77,39,31,30,9,5};

            MemoryStream dataStream = new MemoryStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Position = 0;
            Stream other = dataStream as Stream;
            int result = other.ReadByte();

            byte[] inputData = new byte[result];
            inputData[0] = (byte)result;
            other.Read(inputData, 1, result - 1);


            //Bytes to String
            string s = "";
            foreach (byte b in inputData)
                s += b.ToString()+" ";
            Console.WriteLine(s);
        }
    }
}
