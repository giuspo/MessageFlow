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
		private IActorRef _tBrokerAct;

		public PublishImpl(IActorRef tBrokerAct)
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
