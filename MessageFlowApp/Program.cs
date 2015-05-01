using Akka.Actor;
using MessageFlowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlow
{
	class Program
	{
		private MsgFlowSys _tMsgFlowSys;

		static void Main(string[] args)
		{
			Program tProg = new Program();

			tProg.Init();
			tProg.Run();
		}

		public void Init()
		{
			_tMsgFlowSys = new MsgFlowSys("MainSys");
			_tMsgFlowSys.CreateSub<ActPing>("ActPing");
			_tMsgFlowSys.CreateSub<ActPong>("ActPong");
		}

		public void Run()
		{
			string strLine = "";

			for(;!strLine.Equals("");)
			{
				Console.ReadLine();
			}
		}
	}
}
