using MessageFlowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlow
{
	public class ActPong : MsgFlowAct
	{
		protected override void Init()
		{
			base.Init();

			Subscriber.Subscribe("Ping", SelfAct);
		} 

		protected override void OnMsgFlowRcv(object objMsg)
		{
			if(objMsg is EventMsg)
			{
				var tMsg = (EventMsg)objMsg;

				Publish.SendEvn("Pong", new PongMsg());
			}
		}
	}
}
