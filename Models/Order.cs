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
    
    public partial class Order
    {
        public int ID_order { get; set; }
        public Nullable<int> ID_user { get; set; }
        public Nullable<int> ID_product { get; set; }
        public Nullable<decimal> ord_price { get; set; }
        public Nullable<int> ord_amount { get; set; }
        public Nullable<decimal> ord_total { get; set; }
        public System.DateTime ord_date { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
