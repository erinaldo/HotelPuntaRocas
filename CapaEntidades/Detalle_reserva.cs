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
    
    public partial class Detalle_reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detalle_reserva()
        {
            this.Servicio_habitacion = new HashSet<Servicio_habitacion>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_huesped { get; set; }
        public Nullable<int> id_reserva { get; set; }
        public Nullable<int> indice { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<int> dni_huesped { get; set; }
        public Nullable<int> id_habitacion { get; set; }
        public Nullable<int> id_grupo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicio_habitacion> Servicio_habitacion { get; set; }
        public virtual Reserva Reserva { get; set; }
        public virtual Huesped Huesped { get; set; }
    }
}
