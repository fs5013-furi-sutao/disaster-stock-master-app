using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class MstBranche
    {
        public int Id { get; set; }
        public string Cd { get; set; }
        public string Name { get; set; }
        public string PrefCd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}