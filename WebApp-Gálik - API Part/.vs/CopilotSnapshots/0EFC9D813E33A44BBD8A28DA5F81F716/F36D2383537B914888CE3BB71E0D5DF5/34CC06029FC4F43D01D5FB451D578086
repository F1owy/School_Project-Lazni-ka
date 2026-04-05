using System;
using System.Collections.Generic;

namespace Common.DTO
{
 public class CartDTO
{
   public int ItemsCount { get; set; }
   public float TotalValue { get; set; }
    public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
  }

    public class CartItemDTO
 {
        public int ProductId { get; set; }
  public string ProductName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
  public float Price { get; set; }
  public int Quantity { get; set; }
   public float Subtotal => Price * Quantity;
    }
}
