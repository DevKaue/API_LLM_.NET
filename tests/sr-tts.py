import pyttsx3 # biblioteca de text-to-speech
import speech_recognition as sr # biblioteca para reconhecimento de fala

engine = pyttsx3.init()
engine.setProperty('rate', 215)     # velocidade da fala (padrão ~200)
engine.setProperty('volume', 0.9)   # volume (0.0 a 1.0)

def speak(texto):
    engine.say(texto)
    engine.runAndWait()

recognizer = sr.Recognizer()
mic = sr.Microphone(device_index=2) # definir microfone principal

try:
    with mic as source:
        recognizer.adjust_for_ambient_noise(source, duration=0.2)
        print("Fale algo...")
        audio = recognizer.listen(source, timeout=30, phrase_time_limit=20)

        text = recognizer.recognize_google(audio, language='pt-BR')
        text = text.lower()

        print("Você disse:", text)
        speak(text)

except sr.UnknownValueError:
    print("Não entendi, pode repetir?")
    speak("Não entendi, pode repetir?")
except sr.RequestError as e:
    print(f"Erro ao acessar o serviço de reconhecimento: {e}")
    speak("Houve um erro ao acessar o serviço de voz.")
