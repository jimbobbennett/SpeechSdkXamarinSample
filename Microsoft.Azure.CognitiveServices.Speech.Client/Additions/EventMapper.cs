using System;
using Microsoft.Azure.CognitiveServices.Speech.Util;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    abstract class EventMapper : Java.Lang.Object
    {
        public static void AddEventHandler<T, T1>(ref EventMapper<T, T1> mapper, object sender, EventHandlerImpl handlerImpl, Func<T1, T> argExtractor, EventHandler<EventArgs<T>> value)
            where T : class
            where T1 : class
        {
            if (mapper == null)
            {
                mapper = new EventMapper<T, T1>(sender, argExtractor);
                handlerImpl.AddEventListener(mapper);
            }

            mapper.EventRaised += value;
        }

        public static void RemoveEventHandler<T, T1>(ref EventMapper<T, T1> mapper, EventHandler<EventArgs<T>> value)
            where T : class
            where T1 : class
        {
            if (mapper != null)
                mapper.EventRaised -= value;
        }
    }

    class EventMapper<T, T1> : EventMapper, IEventHandler
            where T : class
            where T1 : class
    {
        public event EventHandler<EventArgs<T>> EventRaised;

        readonly object sender;
        readonly Func<T1, T> argExtractor;

        public EventMapper(object sender, Func<T1, T> argExtractor)
        {
            this.sender = sender;
            this.argExtractor = argExtractor;
        }

        public void OnEvent(Java.Lang.Object p0, Java.Lang.Object p1)
        {
            EventRaised?.Invoke(sender, new EventArgs<T>(argExtractor(p1 as T1)));
        }
    }
}