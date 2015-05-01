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
		public ActorRef SubRef
		{
			get;
			private set;
		}

		public SubscriberRef(ActorRef tActor)
		{
			SubRef = tActor;
		}
	}
}
