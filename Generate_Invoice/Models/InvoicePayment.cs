//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Generate_Invoice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoicePayment
    {
        public int payment_id { get; set; }
        public Nullable<int> invoice_id { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public string payment_mode { get; set; }
        public string payment_description { get; set; }
        public Nullable<double> payment_amount { get; set; }
    
        public virtual InvoiceDetail InvoiceDetail { get; set; }
    }
}
