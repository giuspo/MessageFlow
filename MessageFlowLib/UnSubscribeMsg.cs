using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class UnSubscribeMsg
	{
		public string EventName
		{
			get;
			private set;
		}

		public UnSubscribeMsg(string strEventName)
		{
			EventName = strEventName;
		}
	}
}
