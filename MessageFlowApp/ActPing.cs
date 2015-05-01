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
		protected override void PreStart()
		{
			Context.System.Scheduler.Schedule(TimeSpan.Zero,
				TimeSpan.FromMilliseconds(100),
				Self,
				new TickMsg());

			base.PreStart();
		}

		protected override void OnMsgFlowRcv(object objMsg)
		{
			if(objMsg is TickMsg)
			{
				var tMsg = objMsg as TickMsg;

			}
		}
	}
}
