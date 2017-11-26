using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.ApiConsumer.Model
{
    public class EmailApiModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}