using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public abstract class MsgFlowAct : UntypedActor
	{
		private bool bInitOk = false;

		protected MsgFlowAct() : base()
		{
		}

		protected ISubscriber Subscriber
		{
			get;
			private set;
		}

		protected IPublish Publish
		{
			get;
			private set;
		}

		protected sealed override void OnReceive(object objMsg)
		{
			if(objMsg is InitActorMsg)
			{
				var tMsg = objMsg as InitActorMsg;

				Subscriber = tMsg.Subscriber;
				Publish = tMsg.Publish;

				Init();

				bInitOk = true;
			}
			else if(bInitOk)
			{
				OnMsgFlowRcv(objMsg);
			}
		}

		protected sealed override void PreStart()
		{
			base.PreStart();
		}

		protected virtual void Init()
		{
		}

		protected abstract void OnMsgFlowRcv(object objMsg);
	}
}
