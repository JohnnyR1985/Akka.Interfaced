﻿using System.Threading.Tasks;

namespace Akka.Interfaced
{
    public interface ISubject : IInterfacedActor
    {
        Task MakeEvent(string eventName);
        Task Subscribe(ISubjectObserver observer);
        Task Unsubscribe(ISubjectObserver observer);
    }

    public interface ISubject2 : IInterfacedActor
    {
        Task MakeEvent(string eventName);
        Task MakeEvent2(string eventName);
        Task Subscribe(ISubject2Observer observer);
        Task Unsubscribe(ISubject2Observer observer);
    }

    public interface ISubjectEx : IInterfacedActor
    {
        Task MakeEvent(string eventName);
        Task MakeEventEx(string eventName);
        Task Subscribe(ISubjectExObserver observer);
        Task Unsubscribe(ISubjectExObserver observer);
    }
}
