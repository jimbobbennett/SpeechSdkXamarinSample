using System;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    public partial class Recognizer
    {
        EventMapper<RecognitionEventType, RecognitionEventArgs> recognitionMapper;
        EventMapper<SessionEventType, SessionEventArgs> sessionMapper;

        public event EventHandler<EventArgs<RecognitionEventType>> Recognition
        {
            add => EventMapper.AddEventHandler(ref recognitionMapper, this, RecognitionEvent, e => e.EventType, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionMapper, value);
        }

        public event EventHandler<EventArgs<SessionEventType>> Session
        {
            add => EventMapper.AddEventHandler(ref sessionMapper, this, SessionEvent, e => e.EventType, value);
            remove => EventMapper.RemoveEventHandler(ref sessionMapper, value);
        }
    }
}