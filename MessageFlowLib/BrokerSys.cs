using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Event;

namespace MessageFlowLib
{
	public class BrokerSys : UntypedActor
	{
		private Dictionary<string, List<IActorRef>> _rgtEventSubscriberList;

		protected override void PreStart()
		{
			_rgtEventSubscriberList = new Dictionary<string, List<IActorRef>>();

			base.PreStart();
		}

		protected override void OnReceive(object objMsg)
		{
			if(objMsg is SubscribeMsg)
			{
				var tSubMsg = objMsg as SubscribeMsg;
				bool bIskeyFind = _rgtEventSubscriberList.ContainsKey(tSubMsg.EventName);

				if(!bIskeyFind)
				{
					// SG: Event doesn't exist
					var rgtActorList = new List<IActorRef>();

					// SG: Create new Actor Subscriber List for this Event
					rgtActorList.Add(Sender);
					// SG: Add new Event and Actor to Dictionary
					_rgtEventSubscriberList.Add(tSubMsg.EventName,
						rgtActorList);
					// SG: Watch this Actor
					Context.Watch(Sender);
				}
				else
				{
					// SG: Event already exists
					IList<IActorRef> rgtActorList = _rgtEventSubscriberList[tSubMsg.EventName];
					bool bIsActorFind = rgtActorList.Contains(Sender);

					if(!bIsActorFind)
					{
						// SG: Actor doesn't exist into Subscriber List
						rgtActorList.Add(Sender);
						// SG: Watch this Actor
						Context.Watch(Sender);
					}
				}
			}
			else if(objMsg is UnSubscribeMsg)
			{
				var tUnSubMsg = objMsg as SubscribeMsg;
				bool bIskeyFind = _rgtEventSubscriberList.ContainsKey(tUnSubMsg.EventName);

				if(bIskeyFind)
				{
					// SG: Event already exists
					IList<IActorRef> rgtActorList = _rgtEventSubscriberList[tUnSubMsg.EventName];
					bool bIsActorFind = rgtActorList.Remove(Sender);

					if(bIsActorFind)
					{
						Context.Unwatch(Sender);

						if(0 >= rgtActorList.Count)
						{
							_rgtEventSubscriberList.Remove(tUnSubMsg.EventName);
						}
					}
				}
			}
			else if(objMsg is EventMsg)
			{
				var tEventMsg = objMsg as EventMsg;
				bool bIskeyFind = _rgtEventSubscriberList.ContainsKey(tEventMsg.EventName);

				if(!bIskeyFind)
				{
					foreach(var rgtActor in _rgtEventSubscriberList)
					{
						rgtActor.Value.ForEach(tActorRef =>
							{
								tActorRef.Tell(tEventMsg.Data);
							});
					}
				}
			}
			else if(objMsg is DeadLetter)
			{
				var tDeadMsg = objMsg as DeadLetter;

				foreach(var rgtActor in _rgtEventSubscriberList)
				{
					rgtActor.Value.RemoveAll(tActorRef =>
						{
							return tDeadMsg.Sender == tActorRef;
						});
				}
			}
			else
			{
				Unhandled(objMsg);
			}
		}
	}
}
