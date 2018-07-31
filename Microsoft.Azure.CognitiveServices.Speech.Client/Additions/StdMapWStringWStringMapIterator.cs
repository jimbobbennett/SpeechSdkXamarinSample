using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Microsoft.Azure.CognitiveServices.Speech.Internal
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.microsoft.cognitiveservices.speech.internal']/class[@name='StdMapWStringWStringMapIterator']"
    public partial class StdMapWStringWStringMapIterator
    {
        static Delegate cb_next;
#pragma warning disable 0169
        static Delegate GetNextHandler()
        {
            if (cb_next == null)
                cb_next = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_Next);
            return cb_next;
        }

        static IntPtr n_Next(IntPtr jnienv, IntPtr native__this)
        {
            StdMapWStringWStringMapIterator __this = global::Java.Lang.Object.GetObject<StdMapWStringWStringMapIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.NewString(__this.Next()?.ToString());
        }
#pragma warning restore 0169

        static IntPtr id_next;
        // Metadata.xml XPath method reference: path="/api/package[@name='com.microsoft.cognitiveservices.speech.internal']/class[@name='StdMapWStringWStringMapIterator']/method[@name='next' and count(parameter)=0]"
        [Register("next", "()Ljava/lang/Object;", "GetNextHandler")]
        public virtual unsafe Java.Lang.Object Next()
        {
            if (id_next == IntPtr.Zero)
                id_next = JNIEnv.GetMethodID(class_ref, "next", "()Ljava/lang/Object;");
            try
            {

                if (((object)this).GetType() == ThresholdType)
                    return JNIEnv.GetString(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_next), JniHandleOwnership.TransferLocalRef);
                else
                    return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "next", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
            }
            finally
            {
            }
        }
    }
}
