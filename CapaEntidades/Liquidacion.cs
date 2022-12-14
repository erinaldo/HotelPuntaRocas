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
    
    public partial class Liquidacion
    {
        public int id_liquidacion { get; set; }
        public Nullable<int> id_caja_dia { get; set; }
        public int id_detalle_reserva { get; set; }
        public int id_usuario { get; set; }
        public Nullable<int> id_huesped { get; set; }
        public string cliente_liquidacion { get; set; }
        public string tipo_comprobante_liquidacion { get; set; }
        public string serie_liquidacion { get; set; }
        public string correlativo_liquidacion { get; set; }
        public string concepto_liquidacion { get; set; }
        public string forma_pago_liquidacion { get; set; }
        public System.DateTime fecha_liquidacion { get; set; }
        public Nullable<decimal> descuento_liquidacion { get; set; }
        public decimal sub_total_liquidacion { get; set; }
        public decimal igv_liquidacion { get; set; }
        public decimal total_liquidacion { get; set; }
        public Nullable<decimal> real_liquidacion { get; set; }
        public Nullable<decimal> consumo_liquidacion { get; set; }
        public Nullable<decimal> aumento_liquidacion { get; set; }
        public string referencia_liquidacion { get; set; }
        public string ntarjeta_liquidacion { get; set; }
        public Nullable<bool> estado_tarjeta { get; set; }
        public Nullable<bool> monto_en_caja { get; set; }
        public bool estado_liquidacion { get; set; }
        public Nullable<bool> situacion_liquidacion { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
