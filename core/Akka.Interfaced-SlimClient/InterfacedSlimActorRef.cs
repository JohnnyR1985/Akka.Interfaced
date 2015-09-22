﻿using System;
using System.Threading.Tasks;

namespace Akka.Interfaced
{
    public abstract class InterfacedSlimActorRef
    {
        public ISlimActorRef Actor { get; protected set; }
        public ISlimRequestWaiter RequestWaiter { get; protected set; }
        public TimeSpan? Timeout { get; protected set; }

        public InterfacedSlimActorRef(ISlimActorRef actor, ISlimRequestWaiter requestWaiter, TimeSpan? timeout = null)
        {
            Actor = actor;
            RequestWaiter = requestWaiter;
            Timeout = timeout;
        }

        protected Task SendRequestAndWait(SlimRequestMessage requestMessage)
        {
            return RequestWaiter.SendRequestAndWait(Actor, requestMessage, Timeout);
        }

        protected Task<T> SendRequestAndReceive<T>(SlimRequestMessage requestMessage)
        {
            return RequestWaiter.SendRequestAndReceive<T>(Actor, requestMessage, Timeout);
        }
    }
}
