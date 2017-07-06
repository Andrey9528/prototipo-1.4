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
    
    public partial class tbl_empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_empleado()
        {
            this.tbl_expediente = new HashSet<tbl_expediente>();
            this.tbl_registroIncapacidad = new HashSet<tbl_registroIncapacidad>();
            this.tbl_usuario = new HashSet<tbl_usuario>();
        }
    
        public int Id_empleado { get; set; }
        [Required(ErrorMessage = "Favor digitar el nombre")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Favor digitar el primer apellido")]

        public string Primer_apellido { get; set; }
        [Required(ErrorMessage = "Favor digitar el segundo apellido")]

        public string Segundo_apellido { get; set; }
        [Required(ErrorMessage = "Favor digitar la direcion")]

        public string Direccion { get; set; }
        [Required(ErrorMessage = "Favor digitar el telefono")]
        [DataType (DataType.PhoneNumber)]

        public int Telefono { get; set; }
        [Required(ErrorMessage = "Favor digitar el correo")]
        [DataType (DataType.EmailAddress)]

        public string Correo { get; set; }
        [Required(ErrorMessage = "Favor digitar el estado civil")]

        public string Estado_civil { get; set; }
        [Required(ErrorMessage = "Favor digitar la fecha de nacimiento")]
        [DataType (DataType.Date)]

        public System.DateTime Fecha_naci { get; set; }
        public int Id_departamento { get; set; }
        public int Id_rol { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        public virtual tbl_departamento tbl_departamento { get; set; }
        public virtual tbl_roles tbl_roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_expediente> tbl_expediente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_registroIncapacidad> tbl_registroIncapacidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_usuario> tbl_usuario { get; set; }
    }
}
