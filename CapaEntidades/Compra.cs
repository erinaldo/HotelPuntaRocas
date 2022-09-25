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
    
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            this.Detalle_compra = new HashSet<Detalle_compra>();
        }
    
        public int id { get; set; }
        public int id_proveedor { get; set; }
        public int id_usuario { get; set; }
        public System.DateTime fecha_compra { get; set; }
        public string serie_compra { get; set; }
        public string correlativo_compra { get; set; }
        public string tipo_comprobante { get; set; }
        public decimal igv_compra { get; set; }
        public decimal subtotal_compra { get; set; }
        public decimal total_compra { get; set; }
        public Nullable<System.DateTime> fecha_anulado { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public bool estado_compra { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_compra> Detalle_compra { get; set; }
    }
}
