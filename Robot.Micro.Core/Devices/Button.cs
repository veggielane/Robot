using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core.Linq;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Core.Devices
{
    public enum ButtonState{Released, Pressed}

    public class ButtonEvent
    {
        public ButtonState State;
        public DateTime Time;

        public ButtonEvent(uint state, DateTime time)
        {
            State = state == 0 ? ButtonState.Pressed : ButtonState.Released;
            Time = time;
        }
    }

    public class Button : Observable
    {
        private readonly InterruptPort _port;
        private readonly OutputPort _led;
        public bool LED
        {
            get { return _led.Read(); }
            set { _led.Write(value); }
        }
        public ButtonState State
        {
            get { return _port.Read() ? ButtonState.Pressed : ButtonState.Released; }
        }
        public Button(Cpu.Pin input, Cpu.Pin led)
        {
            _port = new InterruptPort(input,true,Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            _port.OnInterrupt += (data, state, time) => OnNext(new ButtonEvent(state, time));
            _led = new OutputPort(led, false);
        }
    }
}
