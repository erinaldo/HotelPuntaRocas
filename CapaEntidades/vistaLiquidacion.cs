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
    
    public partial class vistaLiquidacion
    {
        public string cliente_liquidacion { get; set; }
        public string serie_comprobante { get; set; }
        public string forma_pago_liquidacion { get; set; }
        public string tipo_comprobante { get; set; }
        public System.DateTime fecha_liquidacion { get; set; }
        public decimal sub_total_liquidacion { get; set; }
        public decimal igv_liquidacion { get; set; }
        public decimal total_liquidacion { get; set; }
        public int id_liquidacion { get; set; }
    }
}