# Xamarin bindings for the Android Cognitive Services Speech SDK

As part of the [Microsoft Cognitive Services speech API](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/?WT.mc_id=speech-github-jabenn), there is a native Java Android SDK available as an `.aar` file. I wanted to use this in a Xamarin app, so created a binding project for it.

You can read more about this on [my blog](https://jimbobbennett.io/binding-the-cognitive-services-android-speech-sdk).

#### Building an using the sameple app

To use the sample app you will need to sign up for a key for the Azure speech services.

* Head to [portal.azure.com](https://portal.azure.com/?WT.mc_id=speech-blog-jabenn) and add a new Speech resource (at the time of writing this is in preview).

* Note down the endpoint from the __Overview__ page. It will be a URL, and you will need the bit before `.api.cognitive.microsoft.com`. For example, if your endpoint is `https://northeurope.api.cognitive.microsoft.com/sts/v1.0`, then you will need `northeurope`. 

* Copy one of the two keys from the __Keys__ page.

Add these values to the constants in `ApiKeys.cs`.