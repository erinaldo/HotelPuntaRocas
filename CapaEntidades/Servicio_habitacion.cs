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
    
    public partial class Servicio_habitacion
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_detalle_reserva { get; set; }
        public int cantidad_servicio_habitacion { get; set; }
        public decimal precio_servicio_habitacion { get; set; }
        public Nullable<System.DateTime> fecha_servicio_habitacion { get; set; }
        public Nullable<int> id_usuario_atiende { get; set; }
        public Nullable<bool> pago_servicio_habitacion { get; set; }
        public Nullable<System.DateTime> fecha_pago_servicio_habitacion { get; set; }
        public Nullable<int> id_usuario_cobra { get; set; }
        public Nullable<int> id_caja_dia { get; set; }
        public bool estado_servicio_habitacion { get; set; }
        public Nullable<int> id_grupo { get; set; }
        public Nullable<bool> estado_factura { get; set; }
    
        public virtual Detalle_reserva Detalle_reserva { get; set; }
    }
}
