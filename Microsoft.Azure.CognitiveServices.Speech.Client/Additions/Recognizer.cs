using System;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    public partial class Recognizer
    {
        EventMapper<RecognitionEventType, RecognitionEventArgs> recognitionHandler;
        EventMapper<SessionEventType, SessionEventArgs> sessionHandler;

        public event EventHandler<EventArgs<RecognitionEventType>> Recognition
        {
            add => EventMapper.AddEventHandler(ref recognitionHandler, RecognitionEvent, e => e.EventType, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionHandler, value);
        }

        public event EventHandler<EventArgs<SessionEventType>> Session
        {
            add => EventMapper.AddEventHandler(ref sessionHandler, SessionEvent, e => e.EventType, value);
            remove => EventMapper.RemoveEventHandler(ref sessionHandler, value);
        }
    }
}