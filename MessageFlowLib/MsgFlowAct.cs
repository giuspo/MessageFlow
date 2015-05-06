using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public abstract class MsgFlowAct : UntypedActor
	{
		private readonly ILoggingAdapter _tLog = Context.GetLogger();

		private bool bInitOk = false;

		protected ILoggingAdapter Log
		{
			get
			{
				return _tLog;
			}
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

		protected SubscriberRef SelfAct
		{
			get
			{
				return new SubscriberRef(Self);
			}
		}

		protected MsgFlowAct() : base()
		{
		}

		protected sealed override void OnReceive(object objMsg)
		{
			if(objMsg is InitActorMsg)
			{
				var tMsg = (InitActorMsg)objMsg;

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
