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
    
    public partial class vistaLiquidacionConsumo
    {
        public int id_liquidacion { get; set; }
        public Nullable<int> id_caja_dia { get; set; }
        public string HUESPED { get; set; }
        public string NSERIE { get; set; }
        public string FORMA_PAGO { get; set; }
        public string TIPO_COMPROBANTE { get; set; }
        public System.DateTime FECHA { get; set; }
        public decimal TOTAL { get; set; }
        public Nullable<System.DateTime> FECHA_COMPARA { get; set; }
        public string forma_pago_liquidacion { get; set; }
    }
}
