using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class SubscriberRef
	{
		public IActorRef SubRef
		{
			get;
			private set;
		}

		public SubscriberRef(IActorRef tActor)
		{
			SubRef = tActor;
		}
	}
}
