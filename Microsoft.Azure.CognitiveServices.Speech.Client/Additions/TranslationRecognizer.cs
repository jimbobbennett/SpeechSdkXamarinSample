using System;

namespace Microsoft.Azure.CognitiveServices.Speech.Translation
{
    public partial class TranslationRecognizer
    {
        EventMapper<TranslationTextResult, TranslationTextResultEventArgs> finalResultHandler;
        EventMapper<TranslationTextResult, TranslationTextResultEventArgs> intermediateResultHandler;
        EventMapper<RecognitionStatus, RecognitionErrorEventArgs> recognitionErrorHandler;
        EventMapper<TranslationSynthesisResult, TranslationSynthesisResultEventArgs> synthesisResultHandler;

        public event EventHandler<EventArgs<TranslationTextResult>> FinalResult
        {
            add => EventMapper.AddEventHandler(ref finalResultHandler, FinalResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref finalResultHandler, value);
        }

        public event EventHandler<EventArgs<TranslationTextResult>> IntermediateResult
        {
            add => EventMapper.AddEventHandler(ref intermediateResultHandler, IntermediateResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref intermediateResultHandler, value);
        }

        public event EventHandler<EventArgs<RecognitionStatus>> RecognitionError
        {
            add => EventMapper.AddEventHandler(ref recognitionErrorHandler, RecognitionErrorRaised, e => e?.Status, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionErrorHandler, value);
        }

        public event EventHandler<EventArgs<TranslationSynthesisResult>> SynthesisResult
        {
            add => EventMapper.AddEventHandler(ref synthesisResultHandler, SynthesisResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref synthesisResultHandler, value);
        }
    }
}