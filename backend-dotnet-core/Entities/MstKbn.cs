using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class MstKbn
    {
        public int Id { get; set; }
        public string Kbn { get; set; }
        public string Cd { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}