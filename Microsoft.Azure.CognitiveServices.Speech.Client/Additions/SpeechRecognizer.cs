using System;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    public partial class SpeechRecognizer
    {
        EventMapper<SpeechRecognitionResult, SpeechRecognitionResultEventArgs> finalResultHandler;
        EventMapper<SpeechRecognitionResult, SpeechRecognitionResultEventArgs> intermediateResultHandler;
        EventMapper<RecognitionStatus, RecognitionErrorEventArgs> recognitionErrorHandler;

        public event EventHandler<EventArgs<SpeechRecognitionResult>> FinalResult
        {
            add => EventMapper.AddEventHandler(ref finalResultHandler, FinalResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref finalResultHandler, value);
        }

        public event EventHandler<EventArgs<SpeechRecognitionResult>> IntermediateResult
        {
            add => EventMapper.AddEventHandler(ref intermediateResultHandler, IntermediateResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref intermediateResultHandler, value);
        }

        public event EventHandler<EventArgs<RecognitionStatus>> RecognitionError
        {
            add => EventMapper.AddEventHandler(ref recognitionErrorHandler, RecognitionErrorRaised, e => e.Status, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionErrorHandler, value);
        }
    }
}