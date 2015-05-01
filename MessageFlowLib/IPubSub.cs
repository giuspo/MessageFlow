using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public interface IPubSub
	{
		void Subscribe(string strEvn,
			SubscriberRef tActor);

		void UnSubscribe(string strEvn,
			SubscriberRef tActor);
	}
}
