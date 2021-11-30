using System;
using System.Collections.Generic;

namespace DotNetCoreApi.Models
{
    public partial class Voucher
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; } = 1;
        public string? Description { get; set; }
        public int Number { get; set; } = 1;
        public decimal Point { get; set; } = 0;
        public int? UserBuyed { get; set; }
        public int? Limit { get; set; } = 0;
        public int? TimeUsed { get; set; } = 0;
    }
}
