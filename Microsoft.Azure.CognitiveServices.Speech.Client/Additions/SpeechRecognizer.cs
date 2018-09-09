using System;

namespace Microsoft.Azure.CognitiveServices.Speech
{
    public partial class SpeechRecognizer
    {
        EventMapper<SpeechRecognitionResult, SpeechRecognitionResultEventArgs> finalResultMapper;
        EventMapper<SpeechRecognitionResult, SpeechRecognitionResultEventArgs> intermediateResultMapper;
        EventMapper<RecognitionStatus, RecognitionErrorEventArgs> recognitionErrorMapper;

        public event EventHandler<EventArgs<SpeechRecognitionResult>> FinalResult
        {
            add => EventMapper.AddEventHandler(ref finalResultMapper, this, FinalResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref finalResultMapper, value);
        }

        public event EventHandler<EventArgs<SpeechRecognitionResult>> IntermediateResult
        {
            add => EventMapper.AddEventHandler(ref intermediateResultMapper, this, IntermediateResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref intermediateResultMapper, value);
        }

        public event EventHandler<EventArgs<RecognitionStatus>> RecognitionError
        {
            add => EventMapper.AddEventHandler(ref recognitionErrorMapper, this, RecognitionErrorRaised, e => e.Status, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionErrorMapper, value);
        }
    }
}