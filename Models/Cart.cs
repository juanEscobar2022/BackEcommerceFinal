//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int ID_cart { get; set; }
        public Nullable<int> ID_user { get; set; }
        public Nullable<int> ID_product { get; set; }
        public Nullable<int> Cant { get; set; }
        public Nullable<decimal> total { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
