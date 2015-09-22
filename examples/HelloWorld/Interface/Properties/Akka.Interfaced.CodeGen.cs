// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Interfaced;

#region HelloWorld.Interface.IHelloWorld

namespace HelloWorld.Interface
{
    [MessageTableForInterfacedActor(typeof(IHelloWorld))]
    public static class IHelloWorld__MessageTable
    {
        public static Type[,] GetMessageTypes()
        {
            return new Type[,]
            {
                {typeof(IHelloWorld__SayHello__Invoke), typeof(IHelloWorld__SayHello__Return)},
                {typeof(IHelloWorld__GetHelloCount__Invoke), typeof(IHelloWorld__GetHelloCount__Return)},
            };
        }
    }

    public class IHelloWorld__SayHello__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        public System.String name;

        public Type GetInterfaceType() { return typeof(IHelloWorld); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IHelloWorld)target).SayHello(name);
            return (IValueGetable)(new IHelloWorld__SayHello__Return { v = __v });
        }
    }

    public class IHelloWorld__SayHello__Return : IInterfacedMessage, IValueGetable
    {
        public System.String v;

        public Type GetInterfaceType() { return typeof(IHelloWorld); }

        public object Value { get { return v; } }
    }

    public class IHelloWorld__GetHelloCount__Invoke : IInterfacedMessage, IAsyncInvokable
    {
        public Type GetInterfaceType() { return typeof(IHelloWorld); }

        public async Task<IValueGetable> Invoke(object target)
        {
            var __v = await((IHelloWorld)target).GetHelloCount();
            return (IValueGetable)(new IHelloWorld__GetHelloCount__Return { v = __v });
        }
    }

    public class IHelloWorld__GetHelloCount__Return : IInterfacedMessage, IValueGetable
    {
        public System.Int32 v;

        public Type GetInterfaceType() { return typeof(IHelloWorld); }

        public object Value { get { return v; } }
    }

    public class HelloWorldRef : InterfacedActorRef, IHelloWorld
    {
        public HelloWorldRef(IActorRef actor)
            : base(actor)
        {
        }

        public HelloWorldRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public HelloWorldRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new HelloWorldRef(Actor, requestWaiter, Timeout);
        }

        public HelloWorldRef WithTimeout(TimeSpan? timeout)
        {
            return new HelloWorldRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.String> SayHello(System.String name)
        {
            var requestMessage = new RequestMessage
            {
                Message = new IHelloWorld__SayHello__Invoke { name = name }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<System.Int32> GetHelloCount()
        {
            var requestMessage = new RequestMessage
            {
                Message = new IHelloWorld__GetHelloCount__Invoke {  }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }
    }
}

#endregion
