using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class SubscriberImpl : ISubscriber
	{
		private IActorRef _tBrokerAct;

		public SubscriberImpl(IActorRef tBrokerAct)
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
