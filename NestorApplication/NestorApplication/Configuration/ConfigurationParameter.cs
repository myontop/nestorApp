﻿using NestorRepository;
using NestorRepository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NestorApplication.Configuration
{
    public class ConfigurationParameter
    {
        public string PortCOM { get; set; }
        public string Baudrate { get; set; }
        public string SkalaTensometr { get; set; }
        public string SkalaDroga { get; set; }
        public string CzuloscStart { get; set; }
        public string DrogaStop { get; set; }
        public string TimeoutStop { get; set; }

        public void Read()
        {
            List<Parametr> dbParameters = DatabaseHelper.ReadConfigurationParameters();

            PortCOM = dbParameters.FirstOrDefault(x => x.Nazwa == "PortCOM").Wartosc;
            Baudrate = dbParameters.FirstOrDefault(x => x.Nazwa == "Baudrate").Wartosc;
            SkalaTensometr = dbParameters.FirstOrDefault(x => x.Nazwa == "SkalaTensometr").Wartosc;
            SkalaDroga = dbParameters.FirstOrDefault(x => x.Nazwa == "SkalaDroga").Wartosc;
            CzuloscStart = dbParameters.FirstOrDefault(x => x.Nazwa == "CzuloscStart").Wartosc;
            DrogaStop = dbParameters.FirstOrDefault(x => x.Nazwa == "DrogaStop").Wartosc;
            TimeoutStop = dbParameters.FirstOrDefault(x => x.Nazwa == "TimeoutStop").Wartosc;
        }

        public void Save(string portCOM, string baudrate, string skalaTensometr, string skalaDroga, string czuloscStart, string drogaStop, string timeoutStop)
        {
            PortCOM = portCOM;
            Baudrate = baudrate;
            SkalaTensometr = skalaTensometr;
            SkalaDroga = skalaDroga;
            CzuloscStart = czuloscStart;
            DrogaStop = drogaStop;
            TimeoutStop = timeoutStop;

            List<Parametr> dbParameters = new List<Parametr>();
            dbParameters.Add(new Parametr { Nazwa = "PortCOM", Wartosc = PortCOM });
            dbParameters.Add(new Parametr { Nazwa = "Baudrate", Wartosc = Baudrate });
            dbParameters.Add(new Parametr { Nazwa = "SkalaTensometr", Wartosc = SkalaTensometr });
            dbParameters.Add(new Parametr { Nazwa = "SkalaDroga", Wartosc = SkalaDroga });
            dbParameters.Add(new Parametr { Nazwa = "CzuloscStart", Wartosc = CzuloscStart });
            dbParameters.Add(new Parametr { Nazwa = "DrogaStop", Wartosc = DrogaStop });
            dbParameters.Add(new Parametr { Nazwa = "TimeoutStop", Wartosc = TimeoutStop });

            DatabaseHelper.SaveParameters(dbParameters);
        }
    }
}
