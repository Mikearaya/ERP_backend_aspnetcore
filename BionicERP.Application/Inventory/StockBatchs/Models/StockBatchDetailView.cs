/*
 * @CreateTime: Sep 2, 2019 4:37 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 2, 2019 4:39 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StockBatchs.Models {
  public class StockBatchDetailView {
    public StockBatchDetailView () {
      Storages = new List<StockLotStorageView> ();
    }
    private float _quantity = 0;

    public uint Id { get; set; }
    public uint ItemId { get; set; }
    public float Quantity {
      get {
        return _quantity;
      }
      set {
        _quantity = value;
      }
    }
    public float? TotalBooked { get; set; }
    public float UnitCost { get; set; }
    public string Status { get; set; }
    public uint? PurchaseOrderId { get; set; }
    public uint? ManufactureOrderId { get; set; }
    public float TotalWriteOff { get; set; }
    public DateTime? DateAdded { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string Item { get; set; }
    public string ItemGroup { get; set; }
    public uint ItemGroupId { get; set; }
    public string Source { get; set; }

    public IEnumerable<StockLotStorageView> Storages { get; set; }

    public static Expression<Func<StockBatch, StockBatchDetailView>> Projection {

      get {
        return stock => new StockBatchDetailView () {
          Id = stock.Id,
          Item = stock.Item.Name,
          ItemId = stock.ItemId,
          Quantity = stock.Quantity,
          TotalBooked = stock.StockBatchStorage
          .Sum (stored => stored.BookedStockBatch
          .Sum (booked => booked.Quantity)),
          UnitCost = stock.UnitCost,
          Status = stock.Status,
          PurchaseOrderId = stock.PurchaseOrderId,
          ManufactureOrderId = stock.ManufactureOrderId,
          DateAdded = stock.DateAdded,
          DateUpdated = stock.DateUpdated,
          AvailableFrom = stock.AvailableFrom,
          Source = stock.Source,
          ExpiryDate = stock.ExpiryDate,
          ItemGroup = stock.Item.Group.GroupName,
          ItemGroupId = stock.Item.GroupId,
          Storages = stock.StockBatchStorage.AsQueryable ().Select (StockLotStorageView.Projection)
        };
      }

    }

  }
}