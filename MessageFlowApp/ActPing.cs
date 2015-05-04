using Akka.Actor;
using MessageFlowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlow
{
	public class ActPing : MsgFlowAct
	{
		protected override void Init()
		{
			Context.System.Scheduler.Schedule(TimeSpan.Zero,
				TimeSpan.FromMilliseconds(100),
				Self,
				new TickMsg());
			
			Subscriber.Subscribe("Pong", SelfAct);
		}

		protected override void OnMsgFlowRcv(object objMsg)
		{
			if(objMsg is TickMsg)
			{
				var tMsg = (TickMsg)objMsg;

				Publish.SendEvn("Ping", new PingMsg());
			}
			else if(objMsg is EventMsg)
			{
				var tMsg = (EventMsg)objMsg;

				if(tMsg.EventName.Equals("Pong"))
				{
				}
			}
		}
	}
}
