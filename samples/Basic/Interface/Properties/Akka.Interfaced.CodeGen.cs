﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Akka.Actor;

#region Basic.Interface.ICalculator

namespace Basic.Interface
{
    [PayloadTable(typeof(ICalculator), PayloadTableKind.Request)]
    public static class ICalculator_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Concat_Invoke), typeof(Concat_Return) },
                { typeof(Sum_Invoke), typeof(Sum_Return) },
            };
        }

        public class Concat_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String a;
            public System.String b;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICalculator)__target).Concat(a, b);
                return (IValueGetable)(new Concat_Return { v = __v });
            }
        }

        public class Concat_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Sum_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 a;
            public System.Int32 b;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICalculator)__target).Sum(a, b);
                return (IValueGetable)(new Sum_Return { v = __v });
            }
        }

        public class Sum_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface ICalculator_NoReply
    {
        void Concat(System.String a, System.String b);
        void Sum(System.Int32 a, System.Int32 b);
    }

    public class CalculatorRef : InterfacedActorRef, ICalculator, ICalculator_NoReply
    {
        public CalculatorRef() : base(null)
        {
        }

        public CalculatorRef(IActorRef actor) : base(actor)
        {
        }

        public CalculatorRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(actor, requestWaiter, timeout)
        {
        }

        public ICalculator_NoReply WithNoReply()
        {
            return this;
        }

        public CalculatorRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new CalculatorRef(Actor, requestWaiter, Timeout);
        }

        public CalculatorRef WithTimeout(TimeSpan? timeout)
        {
            return new CalculatorRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.String> Concat(System.String a, System.String b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Concat_Invoke { a = a, b = b }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<System.Int32> Sum(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Sum_Invoke { a = a, b = b }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        void ICalculator_NoReply.Concat(System.String a, System.String b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Concat_Invoke { a = a, b = b }
            };
            SendRequest(requestMessage);
        }

        void ICalculator_NoReply.Sum(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Sum_Invoke { a = a, b = b }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(ICalculator))]
    public interface ICalculatorSync : IInterfacedActor
    {
        System.String Concat(System.String a, System.String b);
        System.Int32 Sum(System.Int32 a, System.Int32 b);
    }
}

#endregion
#region Basic.Interface.ICounter

namespace Basic.Interface
{
    [PayloadTable(typeof(ICounter), PayloadTableKind.Request)]
    public static class ICounter_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(GetCounter_Invoke), typeof(GetCounter_Return) },
                { typeof(IncCounter_Invoke), null },
            };
        }

        public class GetCounter_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICounter)__target).GetCounter();
                return (IValueGetable)(new GetCounter_Return { v = __v });
            }
        }

        public class GetCounter_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class IncCounter_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 delta;

            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((ICounter)__target).IncCounter(delta);
                return null;
            }
        }
    }

    public interface ICounter_NoReply
    {
        void GetCounter();
        void IncCounter(System.Int32 delta);
    }

    public class CounterRef : InterfacedActorRef, ICounter, ICounter_NoReply
    {
        public CounterRef() : base(null)
        {
        }

        public CounterRef(IActorRef actor) : base(actor)
        {
        }

        public CounterRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(actor, requestWaiter, timeout)
        {
        }

        public ICounter_NoReply WithNoReply()
        {
            return this;
        }

        public CounterRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new CounterRef(Actor, requestWaiter, Timeout);
        }

        public CounterRef WithTimeout(TimeSpan? timeout)
        {
            return new CounterRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Int32> GetCounter()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.GetCounter_Invoke {  }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task IncCounter(System.Int32 delta)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.IncCounter_Invoke { delta = delta }
            };
            return SendRequestAndWait(requestMessage);
        }

        void ICounter_NoReply.GetCounter()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.GetCounter_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void ICounter_NoReply.IncCounter(System.Int32 delta)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.IncCounter_Invoke { delta = delta }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(ICounter))]
    public interface ICounterSync : IInterfacedActor
    {
        System.Int32 GetCounter();
        void IncCounter(System.Int32 delta);
    }
}

#endregion
#region Basic.Interface.IEventGenerator

namespace Basic.Interface
{
    [PayloadTable(typeof(IEventGenerator), PayloadTableKind.Request)]
    public static class IEventGenerator_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Buy_Invoke), null },
                { typeof(Sell_Invoke), null },
                { typeof(Subscribe_Invoke), null },
                { typeof(Unsubscribe_Invoke), null },
            };
        }

        public class Buy_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String name;
            public System.Int32 price;

            public Type GetInterfaceType()
            {
                return typeof(IEventGenerator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IEventGenerator)__target).Buy(name, price);
                return null;
            }
        }

        public class Sell_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String name;
            public System.Int32 price;

            public Type GetInterfaceType()
            {
                return typeof(IEventGenerator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IEventGenerator)__target).Sell(name, price);
                return null;
            }
        }

        public class Subscribe_Invoke
            : IInterfacedPayload, IAsyncInvokable, IPayloadObserverUpdatable
        {
            public Basic.Interface.IEventObserver observer;

            public Type GetInterfaceType()
            {
                return typeof(IEventGenerator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IEventGenerator)__target).Subscribe(observer);
                return null;
            }

            void IPayloadObserverUpdatable.Update(Action<IInterfacedObserver> updater)
            {
                if (observer != null)
                {
                    updater(observer);
                }
            }
        }

        public class Unsubscribe_Invoke
            : IInterfacedPayload, IAsyncInvokable, IPayloadObserverUpdatable
        {
            public Basic.Interface.IEventObserver observer;

            public Type GetInterfaceType()
            {
                return typeof(IEventGenerator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IEventGenerator)__target).Unsubscribe(observer);
                return null;
            }

            void IPayloadObserverUpdatable.Update(Action<IInterfacedObserver> updater)
            {
                if (observer != null)
                {
                    updater(observer);
                }
            }
        }
    }

    public interface IEventGenerator_NoReply
    {
        void Buy(System.String name, System.Int32 price);
        void Sell(System.String name, System.Int32 price);
        void Subscribe(Basic.Interface.IEventObserver observer);
        void Unsubscribe(Basic.Interface.IEventObserver observer);
    }

    public class EventGeneratorRef : InterfacedActorRef, IEventGenerator, IEventGenerator_NoReply
    {
        public EventGeneratorRef() : base(null)
        {
        }

        public EventGeneratorRef(IActorRef actor) : base(actor)
        {
        }

        public EventGeneratorRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(actor, requestWaiter, timeout)
        {
        }

        public IEventGenerator_NoReply WithNoReply()
        {
            return this;
        }

        public EventGeneratorRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new EventGeneratorRef(Actor, requestWaiter, Timeout);
        }

        public EventGeneratorRef WithTimeout(TimeSpan? timeout)
        {
            return new EventGeneratorRef(Actor, RequestWaiter, timeout);
        }

        public Task Buy(System.String name, System.Int32 price)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Buy_Invoke { name = name, price = price }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Sell(System.String name, System.Int32 price)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Sell_Invoke { name = name, price = price }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Subscribe(Basic.Interface.IEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Subscribe_Invoke { observer = (EventObserver)observer }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Unsubscribe(Basic.Interface.IEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Unsubscribe_Invoke { observer = (EventObserver)observer }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IEventGenerator_NoReply.Buy(System.String name, System.Int32 price)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Buy_Invoke { name = name, price = price }
            };
            SendRequest(requestMessage);
        }

        void IEventGenerator_NoReply.Sell(System.String name, System.Int32 price)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Sell_Invoke { name = name, price = price }
            };
            SendRequest(requestMessage);
        }

        void IEventGenerator_NoReply.Subscribe(Basic.Interface.IEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Subscribe_Invoke { observer = (EventObserver)observer }
            };
            SendRequest(requestMessage);
        }

        void IEventGenerator_NoReply.Unsubscribe(Basic.Interface.IEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IEventGenerator_PayloadTable.Unsubscribe_Invoke { observer = (EventObserver)observer }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(IEventGenerator))]
    public interface IEventGeneratorSync : IInterfacedActor
    {
        void Buy(System.String name, System.Int32 price);
        void Sell(System.String name, System.Int32 price);
        void Subscribe(Basic.Interface.IEventObserver observer);
        void Unsubscribe(Basic.Interface.IEventObserver observer);
    }
}

#endregion
#region Basic.Interface.IOverloaded

namespace Basic.Interface
{
    [PayloadTable(typeof(IOverloaded), PayloadTableKind.Request)]
    public static class IOverloaded_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Min_Invoke), typeof(Min_Return) },
                { typeof(Min_2_Invoke), typeof(Min_2_Return) },
                { typeof(Min_3_Invoke), typeof(Min_3_Return) },
            };
        }

        public class Min_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 a;
            public System.Int32 b;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IOverloaded)__target).Min(a, b);
                return (IValueGetable)(new Min_Return { v = __v });
            }
        }

        public class Min_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Min_2_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 a;
            public System.Int32 b;
            public System.Int32 c;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IOverloaded)__target).Min(a, b, c);
                return (IValueGetable)(new Min_2_Return { v = __v });
            }
        }

        public class Min_2_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Min_3_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32[] nums;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IOverloaded)__target).Min(nums);
                return (IValueGetable)(new Min_3_Return { v = __v });
            }
        }

        public class Min_3_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(IOverloaded);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface IOverloaded_NoReply
    {
        void Min(System.Int32 a, System.Int32 b);
        void Min(System.Int32 a, System.Int32 b, System.Int32 c);
        void Min(params System.Int32[] nums);
    }

    public class OverloadedRef : InterfacedActorRef, IOverloaded, IOverloaded_NoReply
    {
        public OverloadedRef() : base(null)
        {
        }

        public OverloadedRef(IActorRef actor) : base(actor)
        {
        }

        public OverloadedRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(actor, requestWaiter, timeout)
        {
        }

        public IOverloaded_NoReply WithNoReply()
        {
            return this;
        }

        public OverloadedRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new OverloadedRef(Actor, requestWaiter, Timeout);
        }

        public OverloadedRef WithTimeout(TimeSpan? timeout)
        {
            return new OverloadedRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Int32> Min(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_Invoke { a = a, b = b }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task<System.Int32> Min(System.Int32 a, System.Int32 b, System.Int32 c)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_2_Invoke { a = a, b = b, c = c }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task<System.Int32> Min(params System.Int32[] nums)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_3_Invoke { nums = nums }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        void IOverloaded_NoReply.Min(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_Invoke { a = a, b = b }
            };
            SendRequest(requestMessage);
        }

        void IOverloaded_NoReply.Min(System.Int32 a, System.Int32 b, System.Int32 c)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_2_Invoke { a = a, b = b, c = c }
            };
            SendRequest(requestMessage);
        }

        void IOverloaded_NoReply.Min(params System.Int32[] nums)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IOverloaded_PayloadTable.Min_3_Invoke { nums = nums }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(IOverloaded))]
    public interface IOverloadedSync : IInterfacedActor
    {
        System.Int32 Min(System.Int32 a, System.Int32 b);
        System.Int32 Min(System.Int32 a, System.Int32 b, System.Int32 c);
        System.Int32 Min(params System.Int32[] nums);
    }
}

#endregion
#region Basic.Interface.IWorker

namespace Basic.Interface
{
    [PayloadTable(typeof(IWorker), PayloadTableKind.Request)]
    public static class IWorker_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Atomic_Invoke), null },
                { typeof(Reentrant_Invoke), null },
            };
        }

        public class Atomic_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String name;

            public Type GetInterfaceType()
            {
                return typeof(IWorker);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IWorker)__target).Atomic(name);
                return null;
            }
        }

        public class Reentrant_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String name;

            public Type GetInterfaceType()
            {
                return typeof(IWorker);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IWorker)__target).Reentrant(name);
                return null;
            }
        }
    }

    public interface IWorker_NoReply
    {
        void Atomic(System.String name);
        void Reentrant(System.String name);
    }

    public class WorkerRef : InterfacedActorRef, IWorker, IWorker_NoReply
    {
        public WorkerRef() : base(null)
        {
        }

        public WorkerRef(IActorRef actor) : base(actor)
        {
        }

        public WorkerRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(actor, requestWaiter, timeout)
        {
        }

        public IWorker_NoReply WithNoReply()
        {
            return this;
        }

        public WorkerRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new WorkerRef(Actor, requestWaiter, Timeout);
        }

        public WorkerRef WithTimeout(TimeSpan? timeout)
        {
            return new WorkerRef(Actor, RequestWaiter, timeout);
        }

        public Task Atomic(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IWorker_PayloadTable.Atomic_Invoke { name = name }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task Reentrant(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IWorker_PayloadTable.Reentrant_Invoke { name = name }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IWorker_NoReply.Atomic(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IWorker_PayloadTable.Atomic_Invoke { name = name }
            };
            SendRequest(requestMessage);
        }

        void IWorker_NoReply.Reentrant(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IWorker_PayloadTable.Reentrant_Invoke { name = name }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(IWorker))]
    public interface IWorkerSync : IInterfacedActor
    {
        void Atomic(System.String name);
        void Reentrant(System.String name);
    }
}

#endregion
#region Basic.Interface.IEventObserver

namespace Basic.Interface
{
    [PayloadTable(typeof(IEventObserver), PayloadTableKind.Notification)]
    public static class IEventObserver_PayloadTable
    {
        public static Type[] GetPayloadTypes()
        {
            return new Type[] {
                typeof(OnBuy_Invoke),
                typeof(OnSell_Invoke),
            };
        }

        public class OnBuy_Invoke : IInterfacedPayload, IInvokable
        {
            public System.String name;
            public System.Int32 price;

            public Type GetInterfaceType()
            {
                return typeof(IEventObserver);
            }

            public void Invoke(object __target)
            {
                ((IEventObserver)__target).OnBuy(name, price);
            }
        }

        public class OnSell_Invoke : IInterfacedPayload, IInvokable
        {
            public System.String name;
            public System.Int32 price;

            public Type GetInterfaceType()
            {
                return typeof(IEventObserver);
            }

            public void Invoke(object __target)
            {
                ((IEventObserver)__target).OnSell(name, price);
            }
        }
    }

    public class EventObserver : InterfacedObserver, IEventObserver
    {
        public EventObserver()
            : base(null, 0)
        {
        }

        public EventObserver(INotificationChannel channel, int observerId = 0)
            : base(channel, observerId)
        {
        }

        public EventObserver(IActorRef target, int observerId = 0)
            : base(new ActorNotificationChannel(target), observerId)
        {
        }

        public void OnBuy(System.String name, System.Int32 price)
        {
            var payload = new IEventObserver_PayloadTable.OnBuy_Invoke { name = name, price = price };
            Notify(payload);
        }

        public void OnSell(System.String name, System.Int32 price)
        {
            var payload = new IEventObserver_PayloadTable.OnSell_Invoke { name = name, price = price };
            Notify(payload);
        }
    }

    [AlternativeInterface(typeof(IEventObserver))]
    public interface IEventObserverAsync : IInterfacedObserver
    {
        Task OnBuy(System.String name, System.Int32 price);
        Task OnSell(System.String name, System.Int32 price);
    }
}

#endregion
