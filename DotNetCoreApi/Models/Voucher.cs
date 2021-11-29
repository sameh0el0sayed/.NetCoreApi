using System;
using System.Collections.Generic;

namespace DotNetCoreApi.Models
{
    public partial class Voucher
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Type { get; set; }
        public string? Description { get; set; }
        public int? Number { get; set; }
        public decimal? Point { get; set; }
        public int? Limit { get; set; }
        public int? TimeUsed { get; set; }
        public int? Criteria { get; set; }
    }
}
