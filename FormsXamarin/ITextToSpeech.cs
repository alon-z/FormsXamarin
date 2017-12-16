using System;
namespace FormsXamarin
{
    public interface ITextToSpeech
    {
        void Speak(String text);
        void LowSpeak(String text);
    }
}
