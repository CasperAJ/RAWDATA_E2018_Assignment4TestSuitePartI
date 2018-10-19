using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        // Creates a Global db variable
        Assignment4Context db = new Assignment4Context();

        // Get Order by id - Task 1
        public Order GetOrder(int orderId)
        {
            var fetchedOrder = new Order();
            var dataSource = db.Orders;
            var linqQuery = dataSource
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Where(x => x.Id.Equals(orderId));

            foreach (var order in linqQuery)
            {
                fetchedOrder.Id = order.Id;
                fetchedOrder.Date = order.Date;
                fetchedOrder.Freight = order.Freight;
                fetchedOrder.Require = order.Require;
                fetchedOrder.ShipCity = order.ShipCity;
                fetchedOrder.ShipName = order.ShipName;
                fetchedOrder.Shipped = order.Shipped;
                fetchedOrder.OrderDetails = order.OrderDetails;
            }

            return fetchedOrder;
        }

        // Get order by shipping name - Task 2
        public List<Order> GetOrdersByShipping(string shippingName)
        {
            var fetchedOrders = new List<Order>();
            var dataSource = db.Orders;
            var lingQuery = dataSource.Where(x=> x.ShipName == shippingName)
                .Select(x => new
            {
                x.Id,
                x.Date,
                x.ShipName,
                x.ShipCity
            });

            foreach (var order in lingQuery)
            {
                var newOrder = new Order();
                newOrder.Id = order.Id;
                newOrder.Date = order.Date;
                newOrder.ShipCity = order.ShipCity;
                newOrder.ShipName = order.ShipName;
                fetchedOrders.Add(newOrder);
            }

            return fetchedOrders;
        }


        // Get orders - Task 3
        public List<Order> GetOrders()
        {
            var fetchedOrders = new List<Order>();
            var dataSource = db.Orders;
            var lingQuery = dataSource.Select(x => new
            {
                x.Id, x.Date, x.ShipName, x.ShipCity
            });

            foreach (var order in lingQuery)
            {
                var newOrder = new Order();
                newOrder.Id = order.Id;
                newOrder.Date = order.Date;
                newOrder.ShipCity = order.ShipCity;
                newOrder.ShipName = order.ShipName;
                fetchedOrders.Add(newOrder);
            }

            return fetchedOrders;
        }

        // Get Orders Details - Task 4
        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            var fetchedOrderDetails = new List<OrderDetails>();

            var dataSource = db.OrderDetails;
            var linqQuery = dataSource
                .Where(x => x.OrderId == orderId)
                .Select(x => new {x.Product, x.UnitPrice, x.Quantity});

            foreach (var OrderDetail in linqQuery)
            {
                var newOrderDetails = new OrderDetails();
                newOrderDetails.Product = OrderDetail.Product;
                newOrderDetails.UnitPrice = OrderDetail.UnitPrice;
                newOrderDetails.Quantity = OrderDetail.Quantity;

                fetchedOrderDetails.Add(newOrderDetails);
            }

            return fetchedOrderDetails;
        }

        // Get Order Details - Task 4
        public List<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            var fetchedOrderDetails = new List<OrderDetails>();

            var dataSource = db.OrderDetails;
            var linqQuery = dataSource
                .Include(x => x.Order)
                .Where(x => x.ProductId == productId)
                .Select(x => new {x.Quantity, x.UnitPrice, x.Order.Date});

            foreach (var OrderDetail in linqQuery)
            {
                var newOrderDetails = new OrderDetails();
                newOrderDetails.Order.Date = OrderDetail.Date;
                newOrderDetails.UnitPrice = OrderDetail.UnitPrice;
                newOrderDetails.Quantity = OrderDetail.Quantity;
                fetchedOrderDetails.Add(newOrderDetails);
            }

            return fetchedOrderDetails;
        }


        // Get Product by id - Task 6
        public Product GetProduct(int wantedId)
        {
            var fetchedProduct = new Product();

            var dataSource = db.Products;
            var linqQuery = dataSource.Where(x => x.Id.Equals(wantedId))
                .Select(x => new { x.Name, x.UnitPrice, x.Category });

            foreach (var productData in linqQuery)
            {
                fetchedProduct.Name = productData.Name;
                fetchedProduct.UnitPrice = productData.UnitPrice;
                fetchedProduct.Category = productData.Category;
            }
            return fetchedProduct;
        }

        // Get Product by name - Task 7
        public List<Product> GetProductByName(string wantedName)
        {
            var productList = new List<Product>();

            var dataSource = db.Products;
            var linqQuery = dataSource.Where(x => x.Name.ToLower().Contains(wantedName.ToLower()))
                .Select(x => new { x.Name, x.Category });

            foreach (var product in linqQuery)
            {
                var newProd = new Product();
                newProd.Name = product.Name;
                newProd.Category = product.Category;

                productList.Add(newProd);
            }
            return productList;
        }

        // Get Product by category - Task 8
        public List<Product> GetProductByCategory(int categoryId)
        {
            var productList = new List<Product>();

            var dataSource = db.Products;
            var linqQuery = dataSource.Where(x => x.CategoryId.Equals(categoryId))
                .Select(x => new { x.Name, x.UnitPrice, x.Category });

            foreach (var product in linqQuery)
            {
                var newProd = new Product();
                newProd.Name = product.Name;
                newProd.UnitPrice = product.UnitPrice;
                newProd.Category = product.Category;

                productList.Add(newProd);
            }
            return productList;
        }
    }
}
