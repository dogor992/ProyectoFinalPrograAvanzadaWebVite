//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.PrograAvanzada.Vite.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract] public partial class CATEGORIA_ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA_ARTICULO()
        {
            this.ARTICULOS = new HashSet<ARTICULOS>();
            this.PERSONA_REPORTANDO_EXTRAVIO = new HashSet<PERSONA_REPORTANDO_EXTRAVIO>();
        }
    
        [DataMember] public int ID { get; set; }
        [DataMember] public string NOMBRE_CATEGORIA { get; set; }
        [DataMember] public string SUBCATEGORIA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICULOS> ARTICULOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA_REPORTANDO_EXTRAVIO> PERSONA_REPORTANDO_EXTRAVIO { get; set; }
    }
}
