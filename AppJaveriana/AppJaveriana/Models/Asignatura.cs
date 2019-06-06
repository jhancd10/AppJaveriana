using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppJaveriana.Models
{
    public class Asignatura : INotifyPropertyChanged
    {
        private long idMateria;

        [JsonProperty("nom")]
        private string nombre;

        [JsonProperty("notp")]
        private string notp;

        [JsonProperty("porci")]
        private string inasistencia;

        [JsonProperty("class_section")]
        private string grupoClase;

        [JsonProperty("crse_id")]
        private long cursoID;

        [JsonProperty("horario")]
        private DiaAsignatura[] horario;

        [JsonProperty("notas")]
        private Notas[] notas;

        [JsonProperty("parciales")]
        private Parciales[] parciales;

        //Eventos
        public event PropertyChangedEventHandler PropertyChanged;

        //GET AND SETTERS
        #region Getters/Setters
        public long IdMateria
        {
            get { return idMateria; }
            set
            {
                idMateria = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        public string Notp
        {
            get { return notp; }
            set
            {
                notp = value;
                OnPropertyChanged();
            }
        }

        public string Inasistencia
        {
            get { return inasistencia; }
            set
            {
                inasistencia = value;
                OnPropertyChanged();
            }
        }

        public string GrupoClase
        {
            get { return grupoClase; }
            set
            {
                grupoClase = value;
                OnPropertyChanged();
            }
        }

        public long CursoID
        {
            get { return cursoID; }
            set
            {
                cursoID = value;
                OnPropertyChanged();
            }
        }

        public DiaAsignatura[] Horario
        {
            get { return horario; }
            set
            {
                horario = value;
                OnPropertyChanged();
            }
        }

        public Notas[] Notas
        {
            get { return notas; }
            set
            {
                notas = value;
                OnPropertyChanged();
            }
        }

        public Parciales[] Parciales
        {
            get { return parciales; }
            set
            {
                parciales = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

    }

    public partial class Notas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Nota { get; set; }
        public int Porcentaje { get; set; }
    }

    public partial class Parciales
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public int Porcentaje { get; set; }
    }
}
