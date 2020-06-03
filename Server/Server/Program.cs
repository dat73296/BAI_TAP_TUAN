using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
			listenerSocket.Bind(ipEnd);
			listenerSocket.Listen(0);
			Console.WriteLine("Server:" + ipEnd.ToString());
			Socket clientSocket = listenerSocket.Accept();
			byte[] Buffer = new byte[clientSocket.SendBufferSize];
			int readByte;
			do {
				readByte = clientSocket.Receive(Buffer);
				byte[] rData = new byte[readByte];
				Array.Copy(Buffer, rData, readByte);
				Console.WriteLine("Data receive:"+System.Text.Encoding.UTF8.GetString(rData));
				
			} while (readByte > 0);
			Console.WriteLine("Client disconnect");
			listenerSocket.Connect(ipEnd);
			
			Console.ReadKey();
		}

	}
}
