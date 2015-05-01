using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class PubSubImpl : IPubSub
	{
		private ActorRef _tBrokerAct;

		public PubSubImpl(ActorRef tBrokerAct)
		{
			_tBrokerAct = tBrokerAct;
		}

		public void Subscribe(string strEvn,
			SubscriberRef tActor)
		{
			_tBrokerAct.Tell(new SubscribeMsg(strEvn),
				tActor.SubRef);
		}

		public void UnSubscribe(string strEvn,
			SubscriberRef tActor)
		{
			_tBrokerAct.Tell(new UnSubscribeMsg(strEvn),
				tActor.SubRef);
		}
	}
}
