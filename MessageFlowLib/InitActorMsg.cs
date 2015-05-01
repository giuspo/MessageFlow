using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class InitActorMsg
	{
		public IPubSub PubSub
		{
			get;
			private set;
		}

		public ISendEvent SendEvn
		{
			get;
			private set;
		}

		public InitActorMsg(IPubSub tPubSub,
			ISendEvent tSendEvn)
		{
			PubSub = tPubSub; 
			SendEvn = tSendEvn;
		}
	}
}
