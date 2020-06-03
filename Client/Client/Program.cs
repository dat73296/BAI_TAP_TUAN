using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	class Program
	{
		
		static void Main(string[] args)
		{
			
			String ip = "127.0.0.1";
			Socket master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(ip), 8888);
			int x = ipEnd.Port;
			master.Connect(ipEnd);
			string y = ipEnd.ToString();
			Console.WriteLine("This is the client: "+ y);
			string sendData = "";	
			do
			{
				Console.Write("Data send server from client: \n");
				sendData = Console.ReadLine();
				foreach(Char c in sendData)
				{
					if(Char.IsDigit(c))
					{		
				int n= Convert.ToInt32(sendData);
						if (n < 10)
						{
							switch (n)
							{
								case 1:
									sendData = "one";
									break;
								case 2:
									sendData = "two";
									break;
								case 3:
									sendData = "three";
									break;
								case 4:
									sendData = "four";
									break;
								case 5:
									sendData = "five";
									break;
								case 6:
									sendData = "six";
									break;
								case 7:
									sendData = "seven";
									break;
								case 8:
									sendData = "eight";
									break;
								case 9:
									sendData = "nine";
									break;
							}
						}
					}
				}
				if (Equals(sendData, "END"))
					sendData = "Good bye";
				master.Send(System.Text.Encoding.UTF8.GetBytes(sendData));
			}
			while (sendData.CompareTo("Good bye") != 0);
				master.Close();
	} }
}
