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
    
    public partial class Huesped
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huesped()
        {
            this.Detalle_reserva = new HashSet<Detalle_reserva>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_empresa { get; set; }
        public string paterno_huesped { get; set; }
        public string materno_huesped { get; set; }
        public string nombre_huesped { get; set; }
        public string dni_huesped { get; set; }
        public string celular_huesped { get; set; }
        public Nullable<bool> estado_huesped { get; set; }
        public string documento_extranjero { get; set; }
        public string email_huesped { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_reserva> Detalle_reserva { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
