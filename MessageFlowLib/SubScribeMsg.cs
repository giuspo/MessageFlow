using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class SubscribeMsg
	{
		public string EventName
		{
			get;
			private set;
		}

		public SubscribeMsg(string strEventName)
		{
			EventName = strEventName;
		}
	}
}
