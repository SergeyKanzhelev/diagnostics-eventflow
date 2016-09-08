﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System;

namespace Microsoft.Diagnostics.EventFlow.Core.Tests
{
    internal class UnitTestInput : IObservable<EventData>, IDisposable
    {
        private SimpleSubject<EventData> subject;
        public UnitTestInput()
        {
            subject = new SimpleSubject<EventData>();
        }

        public void Dispose()
        {
            if (subject != null)
            {
                this.subject.Dispose();
                this.subject = null;
            }
        }

        public void SendMessage(string message)
        {
            var e = new EventData();
            e.Payload["Message"] = message;
            subject.OnNext(e);
        }

        public IDisposable Subscribe(IObserver<EventData> observer)
        {
            return this.subject.Subscribe(observer);
        }
    }
}