//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prototipo_1._3.BD.RRHH
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbl_departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_departamento()
        {
            this.tbl_empleado = new HashSet<tbl_empleado>();
        }


        public int Id_departamento { get; set; }
        [Required (ErrorMessage = "Digite el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite la descripcion")]
        public string Descripcion_d { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_empleado> tbl_empleado { get; set; }
    }
}
