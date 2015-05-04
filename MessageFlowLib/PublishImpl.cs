using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class PublishImpl : IPublish
	{
		private ActorRef _tBrokerAct;

		public PublishImpl(ActorRef tBrokerAct)
		{
			_tBrokerAct = tBrokerAct;
		}

		public void SendEvn(string strEvn,
			object objData)
		{
			_tBrokerAct.Tell(new EventMsg(strEvn,
				objData));
		}
	}
}
