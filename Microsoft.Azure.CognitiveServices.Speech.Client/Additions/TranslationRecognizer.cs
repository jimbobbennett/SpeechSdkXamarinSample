using System;

namespace Microsoft.Azure.CognitiveServices.Speech.Translation
{
    public partial class TranslationRecognizer
    {
        EventMapper<TranslationTextResult, TranslationTextResultEventArgs> finalResultMapper;
        EventMapper<TranslationTextResult, TranslationTextResultEventArgs> intermediateResultMapper;
        EventMapper<RecognitionStatus, RecognitionErrorEventArgs> recognitionErrorMapper;
        EventMapper<TranslationSynthesisResult, TranslationSynthesisResultEventArgs> synthesisResultMapper;

        public event EventHandler<EventArgs<TranslationTextResult>> FinalResult
        {
            add => EventMapper.AddEventHandler(ref finalResultMapper, this, FinalResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref finalResultMapper, value);
        }

        public event EventHandler<EventArgs<TranslationTextResult>> IntermediateResult
        {
            add => EventMapper.AddEventHandler(ref intermediateResultMapper, this, IntermediateResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref intermediateResultMapper, value);
        }

        public event EventHandler<EventArgs<RecognitionStatus>> RecognitionError
        {
            add => EventMapper.AddEventHandler(ref recognitionErrorMapper, this, RecognitionErrorRaised, e => e?.Status, value);
            remove => EventMapper.RemoveEventHandler(ref recognitionErrorMapper, value);
        }

        public event EventHandler<EventArgs<TranslationSynthesisResult>> SynthesisResult
        {
            add => EventMapper.AddEventHandler(ref synthesisResultMapper, this, SynthesisResultReceived, e => e.Result, value);
            remove => EventMapper.RemoveEventHandler(ref synthesisResultMapper, value);
        }
    }
}