﻿using Simcorp.IMS.Phone.Battery;
using Simcorp.IMS.Phone.Speaker;
using Simcorp.IMS.Phone.Keyboard;
using Simcorp.IMS.Phone.Microphone;
using Simcorp.IMS.Phone.Screen;
using Simcorp.IMS.Phone.SimCard;
using System.Text;
using Simcorp.IMS.Phone.Output;
using Simcorp.IMS.Phone.Calls;

namespace Simcorp.IMS.Phone {
    public abstract class BaseMobile {
        public abstract string ModelName { get; }
        public abstract BaseBattery Battery { get; }
        public abstract BaseSpeakerSystem Speaker { get; }
        public abstract BaseKeyboard KeyBoard { get; }
        public abstract BaseMicrophone Microphone { get; }
        public abstract BaseScreen Screen { get; }
        public abstract BaseSimCardSlot SimCard { get; }
        public abstract string SpeakerName { get; }
        public abstract IPlay PlaybackDevice { get; set; }
        public abstract string PlaybackDeviceName { get; set; }
        public abstract IOutput Output { get; set; }
        internal CallGenerator CallGen { get; set; }
        public abstract CallStorage CallStor {get;}

        private void Show(IScreenable screenImage) {
            Screen.Show(screenImage);
        }

        private void FetchNetwork() {
            SimCard.GetSimCardInfo();
        }

        private void FetchSound(ISound sound) {
            Microphone.FetchSound(sound);
        }

        private void ReproduceSound(ISoundable sound) {
            Speaker.Play(sound);
        }

        public void Charge(double energy) {
            Battery.Charge(energy);
        }

        public void Discharge(double energy) {
            Battery.Discharge(energy);
        }

        public virtual string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Model name: {ModelName}");
            descriptionBuilder.AppendLine($"{Battery.ToString()}");
            descriptionBuilder.AppendLine($"{Speaker.ToString()}");
            descriptionBuilder.AppendLine($"Keyboard type : {KeyBoard.ToString()}");
            descriptionBuilder.AppendLine($"Microphone : {Microphone.ToString()}");
            descriptionBuilder.AppendLine($"Sim card : {SimCard.ToString()}");
            descriptionBuilder.AppendLine($"{Screen.ToString()}");
            return descriptionBuilder.ToString();
        }

        public abstract void Play(ISoundable sound);
    }
}