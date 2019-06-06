using System;
using System.Collections.Generic;
using System.Text;

namespace AppJaveriana.Models
{
    public enum MenuItemType
    {
        Asignaturas,
        Horario,
        Noticias
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
