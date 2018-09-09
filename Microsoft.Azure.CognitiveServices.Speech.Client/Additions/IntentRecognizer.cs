using System;

namespace Microsoft.Azure.CognitiveServices.Speech.Intent
{
    public partial class IntentRecognizer
    {
        EventMapper<IntentRecognitionResult, IntentRecognitionResultEventArgs> finalResultMapper;
        EventMapper<IntentRecognitionResult, IntentRecognitionResultEventArgs> intermediateResultMapper;
        EventMapper<RecognitionStatus, RecognitionErrorEventArgs> recognitionErrorMapper;

        public event EventHandler<EventArgs<IntentRecognitionResult>> FinalResult
        {
            add => EventMapper.AddEventHandler(ref finalResultMapper, this, FinalResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref finalResultMapper, value);
        }

        public event EventHandler<EventArgs<IntentRecognitionResult>> IntermediateResult
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