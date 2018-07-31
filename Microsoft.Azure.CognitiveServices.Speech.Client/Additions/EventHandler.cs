using System;
using Microsoft.Azure.CognitiveServices.Speech.Util;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; }
        public EventArgs(T value)
        {
            Value = value;
        }
    }

    abstract class EventMapper : Java.Lang.Object, IEventHandler
    {
        public abstract void OnEvent(Java.Lang.Object p0, Java.Lang.Object p1);

        public static void AddEventHandler<T, T1>(ref EventMapper<T, T1> handler, EventHandlerImpl handlerImpl, Func<T1, T> argExtractor, EventHandler<EventArgs<T>> value)
            where T : class
            where T1 : class
        {
            if (handler == null)
            {
                handler = new EventMapper<T, T1>(argExtractor);
                handlerImpl.AddEventListener(handler);
            }

            handler.EventRaised += value;
        }

        public static void RemoveEventHandler<T, T1>(ref EventMapper<T, T1> handler, EventHandler<EventArgs<T>> value)
            where T : class
            where T1 : class
        {
            if (handler != null)
                handler.EventRaised -= value;
        }
    }

    class EventMapper<T, T1> : EventMapper
            where T : class
            where T1 : class
    {
        public event EventHandler<EventArgs<T>> EventRaised;

        readonly Func<T1, T> argExtractor;

        public EventMapper(Func<T1, T> argExtractor)
        {
            this.argExtractor = argExtractor;
        }

        public override void OnEvent(Java.Lang.Object p0, Java.Lang.Object p1)
        {
            EventRaised?.Invoke(this, new EventArgs<T>(argExtractor(p1 as T1)));
        }
    }
}