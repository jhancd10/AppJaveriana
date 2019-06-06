using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AppJaveriana.Models
{
    public class DiaAsignatura : INotifyPropertyChanged
    {
        private long idDIaAsignatura;

        [JsonProperty("feci")]
        private string feci;

        [JsonProperty("hora")]
        private string hora;

        [JsonProperty("saln")]
        private string saln;

        [JsonProperty("fecf")]
        private string fecf;

        [JsonProperty("doc")]
        private string doc;

        [JsonProperty("dia")]
        private string dia;


        //Eventos
        public event PropertyChangedEventHandler PropertyChanged;

        #region Getters/Setters
        public long IdDIaAsignatura
        {
            get { return idDIaAsignatura; }
            set
            {
                idDIaAsignatura = value;
            }
        }
        public string Feci
        {
            set
            {
                feci = value;
                OnPropertyChanged();
            }
        }

        public string Hora
        {
            set
            {
                hora = value;
                OnPropertyChanged();
            }
        }

        public string Salon
        {
            get { return saln; }
            set
            {
                saln = value;
                OnPropertyChanged();
            }
        }

        public string Fecf
        {
            get { return fecf; }
            set
            {
                fecf = value;
                OnPropertyChanged();
            }
        }

        public string Doc
        {
            get { return doc; }
            set
            {
                doc = value;
                OnPropertyChanged();
            }
        }

        public int GetDia
        {
            get { return Int32.Parse(dia); }
        }

        public string SetDia
        {
            set
            {
                dia = value.ToString();
                OnPropertyChanged();
            }
        }

        public int HoraInicial
        {
            get
            {
                return split(hora)[0];
            }
        }

        public int MinutoInicial
        {
            get
            {
                return split(hora)[1];
            }
        }

        public int HoraFinal
        {
            get
            {
                return split(hora)[2];
            }
        }

        public int MinutoFinal
        {
            get
            {
                return split(hora)[3];
            }
        }

        #endregion

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int[] split(string cadena)
        {
            string regex = @"(\d+):(\d+)\s([-+*/])\s(\d+):(\d+)";
            int[] ans = new int[4];
            foreach(Match m in Regex.Matches(cadena, regex))
            {
                ans[0] = Int32.Parse(m.Groups[1].Value);
                ans[1] = Int32.Parse(m.Groups[2].Value);
                ans[2] = Int32.Parse(m.Groups[4].Value);
                ans[3] = Int32.Parse(m.Groups[5].Value);
            }
            return ans;
            
        }
    }

}
