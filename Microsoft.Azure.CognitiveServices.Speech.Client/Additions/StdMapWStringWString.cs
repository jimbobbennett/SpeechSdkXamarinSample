using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Microsoft.Azure.CognitiveServices.Speech.Internal
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.microsoft.cognitiveservices.speech.internal']/class[@name='StdMapWStringWString']"
    public partial class StdMapWStringWString
    {
        static Delegate cb_iterator;
#pragma warning disable 0169
        static Delegate GetIteratorHandler()
        {
            if (cb_iterator == null)
                cb_iterator = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_Iterator);
            return cb_iterator;
        }

        static IntPtr n_Iterator(IntPtr jnienv, IntPtr native__this)
        {
            StdMapWStringWString __this = global::Java.Lang.Object.GetObject<StdMapWStringWString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.ToLocalJniHandle(__this.Iterator());
        }
#pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='com.microsoft.cognitiveservices.speech.internal']/class[@name='StdMapWStringWString']/method[@name='iterator' and count(parameter)=0]"
        [Register("iterator", "()LJava/Util/Iterator;", "GetIteratorHandler")]
        public virtual unsafe Java.Util.IIterator Iterator()
        {
            const string __id = "iterator.()Lcom/microsoft/cognitiveservices/speech/internal/StdMapWStringWStringMapIterator;";
            try
            {
                var __rm = JniPeerMembers.InstanceMethods.InvokeVirtualObjectMethod(__id, this, null);
                return global::Java.Lang.Object.GetObject<StdMapWStringWStringMapIterator>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            }
            finally
            {
            }
        }

    }
}
