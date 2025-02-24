﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generate_Invoice.Models
{
    public class InvoiceModel
    {
        public int invoice_id { get; set; }
        public string invoice_date { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public float total_amount { get; set; }
        public float paid_amount { get; set; }
        public float remaining_amount { get; set; }
        public string status { get; set; }

    }
}