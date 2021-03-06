﻿using Akka.Actor;
using Akka.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public class MsgFlowSys
	{
		private IActorRef _tBrokerAct;

		public ActorSystem ActorSys
		{
			get;
			private set;
		}

		public MsgFlowSys(string strName)
		{
			ConfigurationFactory.ParseString();

			ActorSys = ActorSystem.Create(strName);
			_tBrokerAct = ActorSys.ActorOf<BrokerSys>(strName + ".Broker");
		}

		public SubscriberRef CreateSub<ActorType>() where ActorType : MsgFlowAct, new()
		{
			IActorRef tActor = ActorSys.ActorOf<ActorType>();

			tActor.Tell(new InitActorMsg(new SubscriberImpl(_tBrokerAct),
				new PublishImpl(_tBrokerAct)));

			return new SubscriberRef(tActor);
		}

		public SubscriberRef CreateSub<ActorType>(string strName) where ActorType : MsgFlowAct, new()
		{
			IActorRef tActor = ActorSys.ActorOf<ActorType>(strName);

			tActor.Tell(new InitActorMsg(new SubscriberImpl(_tBrokerAct),
				new PublishImpl(_tBrokerAct)));

			return new SubscriberRef(tActor);
		}
	}
}
