using Xamarin.Forms;
using FormsXamarin;
using DependencyServiceSample.iOS;
using AVFoundation;
using System;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceSample.iOS
{

    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() { }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 2f,
                Voice = SelectVoice(),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }

        public void LowSpeak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 2,
                Voice = SelectVoice(),
                Volume = 0.3f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }

        AVSpeechSynthesisVoice SelectVoice() {
            AVSpeechSynthesisVoice[] voices = AVSpeechSynthesisVoice.GetSpeechVoices();
            AVSpeechSynthesisVoice voice = null;
            foreach (AVSpeechSynthesisVoice cVoice in voices)
            {
                if (cVoice.Language == "en-US")
                {
                    if (string.Compare(cVoice.Name, "Samantha (Enhanced)", StringComparison.Ordinal) == 0)
                        voice = cVoice;
                }
            }
            if (voice == null)
                voice = AVSpeechSynthesisVoice.FromLanguage("en-US");
            return voice;
        }
    }
}