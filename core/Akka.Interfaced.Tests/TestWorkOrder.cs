﻿using System.Threading.Tasks;
using System.Collections.Generic;
using Akka.Actor;
using Xunit;
using System;
using System.Linq;

namespace Akka.Interfaced.Tests
{
    public class WorkerActor : InterfacedActor<WorkerActor>, IWorker
    {
        private List<Tuple<int, int>> _workLog;

        public WorkerActor(List<Tuple<int, int>> workLog)
        {
            _workLog = workLog;
        }

        async Task IWorker.Atomic(int id)
        {
            _workLog.Add(Tuple.Create(id, 1));
            await Task.Delay(10);
            _workLog.Add(Tuple.Create(id, 2));
            await Task.Delay(10);
            _workLog.Add(Tuple.Create(id, 3));
        }

        [Reentrant]
        async Task IWorker.Reentrant(int id)
        {
            _workLog.Add(Tuple.Create(id, 1));
            await Task.Delay(10);
            _workLog.Add(Tuple.Create(id, 2));
            await Task.Delay(10);
            _workLog.Add(Tuple.Create(id, 3));
        }
    }

    public class TestWorkOrder : Akka.TestKit.Xunit2.TestKit
    {
        [Fact]
        public async Task Test_AtomicHandler()
        {
            var workLog = new List<Tuple<int, int>>();
            var actor = ActorOfAsTestActorRef<WorkerActor>(Props.Create<WorkerActor>(workLog));
            var w = new WorkerRef(actor);
            var t1 = w.Atomic(1);
            var t2 = w.Atomic(2);
            await Task.WhenAll(t1, t2);
            Assert.Equal(new List<Tuple<int, int>>
            {
                Tuple.Create(1, 1),
                Tuple.Create(1, 2),
                Tuple.Create(1, 3),
                Tuple.Create(2, 1),
                Tuple.Create(2, 2),
                Tuple.Create(2, 3),
            }, workLog);
        }

        [Fact]
        public async Task Test_ReentrantHandler()
        {
            var workLog = new List<Tuple<int, int>>();
            var actor = ActorOfAsTestActorRef<WorkerActor>(Props.Create<WorkerActor>(workLog));
            var w = new WorkerRef(actor);
            var t1 = w.Reentrant(1);
            var t2 = w.Reentrant(2);
            await Task.WhenAll(t1, t2);
            Assert.Equal(new List<int> { 1, 1, 2, 2, 3, 3 },
                         workLog.Select(t => t.Item2));
        }

        [Fact]
        public async Task Test_AtomicHandler_ReentrantHandler_Together()
        {
            var workLog = new List<Tuple<int, int>>();
            var actor = ActorOfAsTestActorRef<WorkerActor>(Props.Create<WorkerActor>(workLog));
            var w = new WorkerRef(actor);
            var t1 = w.Reentrant(1);
            var t2 = w.Atomic(2);
            await Task.WhenAll(t1, t2);
            Assert.Equal(new List<Tuple<int, int>>
            {
                Tuple.Create(1, 1),
                Tuple.Create(2, 1),
                Tuple.Create(2, 2),
                Tuple.Create(2, 3),
                Tuple.Create(1, 2),
                Tuple.Create(1, 3),
            }, workLog);
        }
    }
}