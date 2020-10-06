using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class MstDisasterStock
    {
        public int Id { get; set; }
        [Required]
        public string ProductCd { get; set; }
        [Required]
        public string SavingStockKbn { get; set; }
        public string BranchCd { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime StockStartDate { get; set; }
        [Required]
        public DateTime StockEndDate { get; set; }
        [Required]
        public string ReserveBranchCd { get; set; }
        [Required]
        public string StockConditionKbn { get; set; }
        public int Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}