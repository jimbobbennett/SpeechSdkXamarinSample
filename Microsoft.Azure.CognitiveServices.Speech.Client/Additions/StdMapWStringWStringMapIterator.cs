using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Microsoft.Azure.CognitiveServices.Speech.Internal
{
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
            var __this = global::Java.Lang.Object.GetObject<StdMapWStringWStringMapIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.NewString(__this.Next().ToString());
        }
#pragma warning restore 0169

        [Register("next", "()Ljava/lang/String;", "GetNextHandler")]
        public virtual unsafe Java.Lang.Object Next()
        {
            const string __id = "next.()Ljava/lang/String;";
            try
            {
                var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, null);
                return JNIEnv.GetString(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            }
            finally
            {
            }
        }
    }
}
