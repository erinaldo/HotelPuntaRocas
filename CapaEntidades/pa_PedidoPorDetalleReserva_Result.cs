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
    
    public partial class pa_PedidoPorDetalleReserva_Result
    {
        public int id_detalle_reserva { get; set; }
        public Nullable<System.DateTime> fecha_atencion { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<System.DateTime> fecha_hora_atencion { get; set; }
        public Nullable<System.DateTime> fecha_hora_pago { get; set; }
        public Nullable<decimal> Pago { get; set; }
        public Nullable<decimal> Debe { get; set; }
    }
}
