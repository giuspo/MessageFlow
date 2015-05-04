using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public interface ISubscriber
	{
		void Subscribe(string strEvn,
			SubscriberRef tMsgFlowAct);

		void UnSubscribe(string strEvn,
			SubscriberRef tMsgFlowAct);
	}
}
