using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 468. Validate IP Address - https://leetcode.com/problems/validate-ip-address/ - AC
    public class ValidateIPAddress_468
    {
        public string ValidIPAddress(string IP)
        {
            string result = "IPv4";
            string result2 = "IPv6";
            string result3 = "Neither";

            {
                if (string.IsNullOrEmpty(IP))
                {
                    return result3;
                }
            }

            {
                string[] address = IP.Split('.');

                //ip v4
                if(address.Length == 4)
                {
                    try
                    {
                        foreach (string s in address)
                        {
                            int temp = int.Parse(s);

                            if (temp < 0) return result3;

                            if(temp == 0)
                            {
                                if (s.Length > 1)
                                    return result3;
                            }

                            if (temp>0 &&(int)Math.Log10(temp) != s.Length - 1)
                            {
                                return result3;
                            }

                            

                            if(temp > 255)
                            {
                                return result3;
                            }
                        }

                        return result;
                    }
                    catch (Exception)
                    {
                        // exception of int parse
                        return result3;
                    }
                }

            }

            {
                string[] address = IP.Split(':');

                if (address.Length == 8)
                {

                    foreach (string s in address)
                    {
                        if (s.Length > 4)
                        {
                            return result3;
                        }

                        if (s.Length == 0)
                            return result3;

                        string temp = s.ToLower();
                        for (int i = 0; i < temp.Length; i++)
                        {
                            char c = temp[i];

                            if (c - '0' >= 0 && c - '0' <= 9)
                            {
                                continue;
                            }
                            else if (c - 'a' >= 0 && c - 'a' <= 5)
                            {
                                continue;
                            }
                            else
                            {
                                return result3;
                            }
                        }

                    }

                    return result2;

                }

             }

            return result3;
        }
        public static void main()
        {
            ValidateIPAddress_468 s = new ValidateIPAddress_468();
            string[] ipAddress = new string[] { "192.0.0.1","1.1.1.1", "172.16.254.1", "172.16.254.01", "2001:db8:85a3:0:0:8A2E:0370:7334", "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "2001:0db8:85a3::8A2E:0370:7334", "02001:0db8:85a3:0000:0000:8a2e:0370:7334" };

            foreach(string x in ipAddress)
            {
                Console.WriteLine(s.ValidIPAddress(x));
            }

        }
    }
}
