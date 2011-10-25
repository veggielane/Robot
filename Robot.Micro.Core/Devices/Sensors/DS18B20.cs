using System;
using GHIElectronics.NETMF.Hardware;
using Microsoft.SPOT;
//http://datasheets.maxim-ic.com/en/ds/DS18B20.pdf
//http://wiki.tinyclr.com/images/3/3b/DS18B20.cs
//http://www.ghielectronics.com/downloads/NETMF/Library%20Documentation/html/b33d5f99-cd45-14ee-99e8-8a8ebfa78181.htm

namespace Robot.Micro.Core.Devices.Sensors
{
    public class DS18B20
    {
        public const byte SearchROM = 0xF0;
        public const byte ReadROM = 0x33;
        public const byte MatchROM = 0x55;
        public const byte SkipROM = 0xCC;
        public const byte AlarmSearch = 0xEC;
        public const byte StartTemperatureConversion = 0x44;
        public const byte ReadScratchPad = 0xBE;
        public const byte WriteScratchPad = 0x4E;
        public const byte CopySratchPad = 0x48;
        public const byte RecallEEPROM = 0xB8;
        public const byte ReadPowerSupply = 0xB4;

        private readonly byte[] _address = new byte[8];

        public DS18B20(OneWire oneWire, byte[] address)
        {
            if (address.Length != 8) throw Error.ArgumentException("Invalid Address Length");
            _address = address;
            if (!oneWire.Reset() || !oneWire.Search_IsDevicePresent(_address))
            {
                throw Error.ArgumentNullException("Cant Find Sensor");
            }
        }
    }
}

/*
 * 
 * 
 * using System;
using System.Text;
using System.Collections;
using Microsoft.SPOT;
using GHIElectronics.NETMF.Hardware;

namespace Brewery.Core
{
    public class DS18B20
    {
        byte[] Address = new byte[8];
        double Temperature;

        public override string ToString()
        {
            string output = ""; ;
            for (int i = 0; i < 8; i++)
            {
                output += Address[i];
                if (i != 7)
                {
                    output += ":";
                }
            }
            output += " - " + Temperature;
            return output;
        }

        public static DS18B20[] GetAll(OneWire ow)
        {
            DS18B20[] sensors;
            int OW_number;
            double temperature;
            byte[] OW_address = new byte[8];
            if (ow.Reset())
            {
                OW_number = 0;
                while (ow.Search_GetNextDevice(OW_address))
                {
                    OW_number++;
                }
                sensors = new DS18B20[OW_number];

                OW_number = 0;
                if (ow.Reset())
                {
                    while (ow.Search_GetNextDevice(OW_address))
                    {
                        ow.WriteByte(0xCC);     // Skip ROM
                        ow.WriteByte(0x44);     // Start temperature conversion

                        while (ow.ReadByte() == 0)
                            ;   // wait while busy
                        ow.Reset();
                        ow.WriteByte(0xCC);     // skip ROM
                        ow.WriteByte(0xBE);     // Read Scratchpad

                        temperature = ow.ReadByte() | (int)(ow.ReadByte() << 8);
                        temperature = ((6 * (int)temperature) + (int)temperature / 4) / 100.0;

                        Debug.Print("Temperature: " + temperature);
                        sensors[OW_number] = new DS18B20() { Address = OW_address, Temperature = temperature / 16.0 };
                        OW_number++;
                    }
                }
            }
            else
            {
                sensors = new DS18B20[0];
            }
            return sensors;
        }
    }
}

 * 
 */
