using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class InitActorMsg
	{
		public ISubscriber Subscriber
		{
			get;
			private set;
		}

		public IPublish Publish
		{
			get;
			private set;
		}

		public InitActorMsg(ISubscriber tSubscriber,
			IPublish tPublish)
		{
			Subscriber = tSubscriber; 
			Publish = tPublish;
		}
	}
}
