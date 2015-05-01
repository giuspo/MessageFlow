using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class EventMsg
	{
		public string EventName
		{
			get;
			private set;
		}

		public object Data
		{
			get;
			private set;
		}

		public EventMsg(string strEventName,
			object objData)
		{
			EventName = strEventName;
			Data = objData;
		}
	}
}
