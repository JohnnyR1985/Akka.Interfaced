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

#region Akka.Interfaced.TestKit.Tests.IUser

namespace Akka.Interfaced.TestKit.Tests
{
    [PayloadTableForInterfacedActor(typeof(IUser))]
    public static class IUser_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,]
            {
                {typeof(GetId_Invoke), typeof(GetId_Return)},
                {typeof(Say_Invoke), null},
            };
        }

        public class GetId_Invoke : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType() { return typeof(IUser); }

            public async Task<IValueGetable> InvokeAsync(object target)
            {
                var __v = await((IUser)target).GetId();
                return (IValueGetable)(new GetId_Return { v = __v });
            }
        }

        public class GetId_Return : IInterfacedPayload, IValueGetable
        {
            public System.String v;

            public Type GetInterfaceType() { return typeof(IUser); }

            public object Value { get { return v; } }
        }

        public class Say_Invoke : IInterfacedPayload, IAsyncInvokable
        {
            public System.String message;

            public Type GetInterfaceType() { return typeof(IUser); }

            public async Task<IValueGetable> InvokeAsync(object target)
            {
                await ((IUser)target).Say(message);
                return null;
            }
        }
    }

    public interface IUser_NoReply
    {
        void GetId();
        void Say(System.String message);
    }

    public class UserRef : InterfacedActorRef, IUser, IUser_NoReply
    {
        public UserRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public IUser_NoReply WithNoReply()
        {
            return this;
        }

        public UserRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserRef(Actor, requestWaiter, Timeout);
        }

        public UserRef WithTimeout(TimeSpan? timeout)
        {
            return new UserRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.String> GetId()
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUser_PayloadTable.GetId_Invoke {  }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task Say(System.String message)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUser_PayloadTable.Say_Invoke { message = message }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IUser_NoReply.GetId()
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUser_PayloadTable.GetId_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void IUser_NoReply.Say(System.String message)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUser_PayloadTable.Say_Invoke { message = message }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion

#region Akka.Interfaced.TestKit.Tests.IUserLogin

namespace Akka.Interfaced.TestKit.Tests
{
    [PayloadTableForInterfacedActor(typeof(IUserLogin))]
    public static class IUserLogin_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,]
            {
                {typeof(Login_Invoke), typeof(Login_Return)},
            };
        }

        public class Login_Invoke : IInterfacedPayload, IAsyncInvokable
        {
            public System.String id;
            public System.String password;
            public System.Int32 observerId;

            public Type GetInterfaceType() { return typeof(IUserLogin); }

            public async Task<IValueGetable> InvokeAsync(object target)
            {
                var __v = await((IUserLogin)target).Login(id, password, observerId);
                return (IValueGetable)(new Login_Return { v = __v });
            }
        }

        public class Login_Return : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType() { return typeof(IUserLogin); }

            public object Value { get { return v; } }
        }
    }

    public interface IUserLogin_NoReply
    {
        void Login(System.String id, System.String password, System.Int32 observerId);
    }

    public class UserLoginRef : InterfacedActorRef, IUserLogin, IUserLogin_NoReply
    {
        public UserLoginRef(IActorRef actor)
            : base(actor)
        {
        }

        public UserLoginRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public IUserLogin_NoReply WithNoReply()
        {
            return this;
        }

        public UserLoginRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserLoginRef(Actor, requestWaiter, Timeout);
        }

        public UserLoginRef WithTimeout(TimeSpan? timeout)
        {
            return new UserLoginRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Int32> Login(System.String id, System.String password, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUserLogin_PayloadTable.Login_Invoke { id = id, password = password, observerId = observerId }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        void IUserLogin_NoReply.Login(System.String id, System.String password, System.Int32 observerId)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IUserLogin_PayloadTable.Login_Invoke { id = id, password = password, observerId = observerId }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion

#region Akka.Interfaced.TestKit.Tests.IUserObserver

namespace Akka.Interfaced.TestKit.Tests
{
    public static class IUserObserver_PayloadTable
    {
        public class Say_Invoke : IInvokable
        {
            public System.String message;

            public void Invoke(object target)
            {
                ((IUserObserver)target).Say(message);
            }
        }
    }

    public class UserObserver : InterfacedObserver, IUserObserver
    {
        public UserObserver(IActorRef target, int observerId)
            : base(new ActorNotificationChannel(target), observerId)
        {
        }

        public UserObserver(INotificationChannel channel, int observerId)
            : base(channel, observerId)
        {
        }

        public void Say(System.String message)
        {
            var payload = new IUserObserver_PayloadTable.Say_Invoke { message = message };
            Notify(payload);
        }
    }
}

#endregion
