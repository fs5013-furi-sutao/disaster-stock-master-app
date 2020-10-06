using System;

namespace WebApi.Models.Products
{
  public class MstProductModel
    {
        public int Id { get; set; }
        public string Cd { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public string ManufactureCd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}