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
    using System.Collections.Generic;
    
    public partial class vistaUnirFactura
    {
        public int id { get; set; }
        public Nullable<int> codigo_reserva { get; set; }
        public Nullable<System.DateTime> fecha_hotelera { get; set; }
        public Nullable<int> grupo_reserva { get; set; }
        public string piso { get; set; }
        public string nombre_tarifa_habitacion { get; set; }
        public decimal precio_tarifa_habitacion { get; set; }
        public string completo_huesped { get; set; }
    }
}
