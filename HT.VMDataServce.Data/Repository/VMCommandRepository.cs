using HT.VMDataServce.Data.Models;
using HT.VMDataServce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT.VMDataServce.Data.Repository
{
    public class VMCommandRepository
    {
        internal HTVMDEVDB01Context _context;

        public VMCommandRepository(HTVMDEVDB01Context context)
        {
            _context = context;
        }

        public int NewSalesOrder(SalesOrder model)
        {
            try
            {
                return SaveSalesOrder(model);
            }
            catch
            {
                throw;
            }            
        }

        private int SaveSalesOrder(SalesOrder model)
        {
            var orderTotal = (from ot in model.OrderDetails
                              select ot.LineItemTotal).Sum();

            List<OrderItem> orderItems = new List<OrderItem>();

            ProductInventory[] entites = 
                new ProductInventory[model.OrderDetails.Count];
            int index = 0;

            model.OrderDetails.ForEach(item =>
            {
                orderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    LineItemTotal = item.LineItemTotal
                });

                int quantityInStock =
                _context.ProductInventories.FirstOrDefault(i => i.ProductId == item.ProductId).QtyInStock;

                entites[index] = new ProductInventory
                {
                    ProductId = item.ProductId,
                    QtyInStock = (quantityInStock - item.Quantity)
                };
            }
            );
            
            OrderPayment payment = new OrderPayment
            {
                Amount = model.PaymentDetails.Amount,
                AmountPaid = model.PaymentDetails.AmountPaid,
                AmountReturned = (model.PaymentDetails.AmountPaid - model.PaymentDetails.Amount),
                PaymentDate = DateTime.UtcNow
            };
            List<OrderPayment> payments = new List<OrderPayment>();
            payments.Add(payment);

            _context.Orders.Add(new Order
            {
                OrderDate = System.DateTime.UtcNow,
                OrderValue = orderTotal,
                OrderItems = orderItems,
                OrderPayments = payments
            });           

            _context.ProductInventories.UpdateRange(entites);

            return _context.SaveChanges();
        }
    }
}
