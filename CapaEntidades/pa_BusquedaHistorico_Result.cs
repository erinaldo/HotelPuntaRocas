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
    
    public partial class pa_BusquedaHistorico_Result
    {
        public Nullable<int> id_reserva { get; set; }
        public string habitacion { get; set; }
        public string completo_huesped { get; set; }
        public Nullable<System.DateTime> fecha_checkin { get; set; }
        public Nullable<System.DateTime> fecha_checout { get; set; }
        public string Tarifa { get; set; }
        public Nullable<int> dias { get; set; }
        public Nullable<decimal> total_hospedaje { get; set; }
        public Nullable<decimal> consumo { get; set; }
    }
}