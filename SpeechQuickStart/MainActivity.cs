using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using Microsoft.Azure.CognitiveServices.Speech;
using Android.Runtime;
using System.Collections.Generic;
using Android.Media;
using Java.IO;
using Microsoft.Azure.CognitiveServices.Speech.Translation;
using System.Linq;

namespace SpeechQuickStart
{
    [Activity(Label = "SpeechQuickStart", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        TextView _intermediateOutput;
        TextView IntermediateOutput => _intermediateOutput ?? (_intermediateOutput = (TextView)FindViewById(Resource.Id.intermediate_output));

        TextView _fullOutput;
        TextView FullOutput => _fullOutput ?? (_fullOutput = (TextView)FindViewById(Resource.Id.full_output));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Note: we need to request the permissions
            var requestCode = 5; // unique code for the permission request
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RecordAudio, Manifest.Permission.Internet }, requestCode);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            SpeechFactory.ConfigureNativePlatformBindingWithDefaultCertificate();
            factory = SpeechFactory.FromSubscription(ApiKeys.SpeechApiKey, ApiKeys.ServiceRegion);

            ListenForSpeech();
        }

        TranslationRecognizer translationReco;
        SpeechFactory factory;

        private void ListenForSpeech()
        {
            try
            {
                translationReco = factory.CreateTranslationRecognizer("en-US", new List<string> { "de" }, "de-DE-Hedda");
                //var reco = factory.CreateSpeechRecognizer();

                //reco.IntermediateResult += (s, e) =>
                //{
                //    Log.Info("SpeechSDKDemo", "Intermediate result " + e.Value.Text);
                //    if (!string.IsNullOrWhiteSpace(e.Value.Text))
                //    {
                //        RunOnUiThread(() => IntermediateOutput.Text = e.Value.Text);
                //    }
                //};

                //reco.FinalResult += (s, e) =>
                //{
                //    Log.Info("SpeechSDKDemo", "Final result " + e.Value.Text);
                //    if (!string.IsNullOrWhiteSpace(e.Value.Text))
                //    {
                //        RunOnUiThread(() => FullOutput.Text += $"{ e.Value.Text} ");
                //    }
                //};

                translationReco.SynthesisResult += (s, e) =>
                {
                    Log.Info("SpeechSDKDemo", "Synthesis Result" + e.Value.SynthesisStatus.ToString());
                    if (e.Value.SynthesisStatus == SynthesisStatus.Success)
                        PlayWay(e.Value.GetAudio());
                };

                translationReco.FinalResult += (s, e) =>
                {
                    Log.Info("SpeechSDKDemo", "Final result " + e.Value.Text);
                    if (!string.IsNullOrWhiteSpace(e.Value.Text))
                    {
                        RunOnUiThread(() => FullOutput.Text += $"{ e.Value.Translations["de"]} ");
                    }
                };

                translationReco.IntermediateResult += (s, e) =>
                {
                    Log.Info("SpeechSDKDemo", "Translation intermediate result " + e.Value.Text);
                    if (!string.IsNullOrWhiteSpace(e.Value.Text))
                    {
                        RunOnUiThread(() => IntermediateOutput.Text = $"{e.Value.Text} - { e.Value.Translations["de"]} ");
                    }
                };

                translationReco.RecognitionError += (s, e) =>
                {
                    Log.Info("SpeechSDKDemo", "Error result " + e.Value?.Name());
                };

                translationReco.StartContinuousRecognitionAsync();
                //reco.StartContinuousRecognitionAsync();
            }
            catch (Exception ex)
            {
                Log.Error("SpeechSDKDemo", "unexpected " + ex.Message);
            }
        }

        private MediaPlayer mediaPlayer = new MediaPlayer();

        private void PlayWay(byte[] audio)
        {
            if (!audio.Any()) return;

            try
            {
                RunOnUiThread(() => IntermediateOutput.Text = "Please wait...");

                var tempWav = File.CreateTempFile("kurchina", "wav", CacheDir);
                tempWav.DeleteOnExit();

                var fos = new FileOutputStream(tempWav);
                fos.Write(audio);
                fos.Close();
                
                mediaPlayer.Reset();
                
                var fis = new FileInputStream(tempWav);
                mediaPlayer.SetDataSource(fis.FD);

                translationReco.StopContinuousRecognitionAsync();
                mediaPlayer.Completion += (s, e) =>
                {
                    RunOnUiThread(() =>
                    {
                        ListenForSpeech();
                        IntermediateOutput.Text = "Start speaking...";
                        FullOutput.Text = "";
                    });
                };
                mediaPlayer.Prepare();
                mediaPlayer.Start();
            }
            catch (IOException ex)
            {
                ex.PrintStackTrace();
            }
        }
    }
}

