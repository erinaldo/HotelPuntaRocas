//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaEntidades
{
    using System;
    
    public partial class pa_UltimaObservacion_Result
    {
        public int id { get; set; }
        public int id_detalle_reserva { get; set; }
        public Nullable<int> id_huesped { get; set; }
        public string nombre_huesped { get; set; }
        public string dni_huesped { get; set; }
        public string comentario_calificacion { get; set; }
        public System.DateTime fecha_calificacion { get; set; }
        public int puntos_calificacion { get; set; }
    }
}
