using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // start:
            Ping p = new Ping();
            Console.WriteLine("Please Enter the Ip");
            string IpPing = Console.ReadLine();


            for (; ; )
            {
                PingReply rep = p.Send(IpPing, 1000);
                if (rep.Status.ToString() == "Success")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("Reply From: " + rep.Address + " Bytes=" + rep.Buffer.Length + " Time=" + rep.RoundtripTime + " TTL=" + rep.Options.Ttl + " Routers=" + (128 - rep.Options.Ttl) + " Status=" + rep.Status);
                    Thread.Sleep(100);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Request Timed Out");
                    Thread.Sleep(100);
                }
                //goto start;
            }

        }
    }
}
