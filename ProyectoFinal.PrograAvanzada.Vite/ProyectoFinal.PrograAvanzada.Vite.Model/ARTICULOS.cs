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

    [DataContract] public partial class ARTICULOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTICULOS()
        {
            this.PERSONA_ENTREGANDO = new HashSet<PERSONA_ENTREGANDO>();
        }
    
        [DataMember] public int ID { get; set; }
        [DataMember] public Nullable<int> ID_CATEGORIA { get; set; }
        [DataMember] public string ESTADO { get; set; }
        [DataMember] public string MARCA { get; set; }
        [DataMember] public string MODELO { get; set; }
        [DataMember] public string DESCRIPCION { get; set; }
        [DataMember] public string FOTOS { get; set; }
    
        public virtual CATEGORIA_ARTICULO CATEGORIA_ARTICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA_ENTREGANDO> PERSONA_ENTREGANDO { get; set; }
    }
}
