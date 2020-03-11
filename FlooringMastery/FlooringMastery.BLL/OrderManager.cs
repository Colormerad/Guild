using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IStateTaxRepository _stateTaxRepository;
        public  OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, IStateTaxRepository stateTaxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _stateTaxRepository = stateTaxRepository;

        }

        public OrderLookupResponse LookupOrder(DateTime orderDate, int orderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            response.Order = _orderRepository.ReadById(orderDate, orderNumber);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} is not a valid order.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public StateLookupResponse LookupState(Order order)
        {
            StateLookupResponse response = new StateLookupResponse();
            response.state = _stateTaxRepository.ReadByStateAbbreviation(order);
            if (response.state == null)
            {
                response.Success = false;
                response.Message = $"{order.State} is not a valid state.";
            }
            else
            {
                response.Success = true;
            }
            return response;

        }


        public ProductLookupResponse LookupProduct(Order order)
        {
            ProductLookupResponse response = new ProductLookupResponse();
            response.product = _productRepository.ReadByProductType(order);
            if (response.product == null)
            {
                response.Success = false;
                response.Message = $"{order.ProductType} is not a valid product type.";
            }
            else
            {
                response.Success = true;
            }

            return response;

        }

        public OrdersLookupResponse LookupOrders(DateTime orderDate)
        {
            OrdersLookupResponse response = new OrdersLookupResponse();
            response.Orders = _orderRepository.ReadAllByDate(orderDate);

            if(response.Orders == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not a valid date";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddOrderResponse AddOrder(Order order)
        {
            State state = new State();
            Product product = new Product();
            AddOrderResponse response = new AddOrderResponse();
            state = _stateTaxRepository.ReadByStateAbbreviation(order);           
            product = _productRepository.ReadByProductType(order);

            

            decimal TaxRate = state.TaxRate;
            decimal CostPerSquareFoot = product.CostPerSqareFoot;
            decimal LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            order.State = state.StateAbbreviation;
            order.TaxRate = TaxRate;
            order.ProductType = product.ProductType;
            order.CostPerSqareFoot = CostPerSquareFoot;
            order.LaborCostPerSquareFoot = LaborCostPerSquareFoot;
            order.MaterialCost = (order.Area * CostPerSquareFoot);
            order.LaborCost = (order.Area * LaborCostPerSquareFoot);
            order.Tax = ((order.MaterialCost + order.LaborCost) * (TaxRate / 100));
            order.Total = (order.MaterialCost + order.LaborCost + order.Tax);

            response.Order = _orderRepository.Create(order);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Something went wrong";
            }
            else
            {
                response.Success = true;
            }
            return response;

        }

        public EditOrderResponse EditOrder(Order order)
        {
            State state = new State();
            Product product = new Product();
            EditOrderResponse response = new EditOrderResponse();
            state = _stateTaxRepository.ReadByStateAbbreviation(order);
            product = _productRepository.ReadByProductType(order);

            decimal TaxRate = state.TaxRate;
            decimal CostPerSquareFoot = product.CostPerSqareFoot;
            decimal LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            order.State = state.StateAbbreviation;
            order.TaxRate = TaxRate;
            order.ProductType = product.ProductType;
            order.CostPerSqareFoot = CostPerSquareFoot;
            order.LaborCostPerSquareFoot = LaborCostPerSquareFoot;
            order.MaterialCost = (order.Area * CostPerSquareFoot);
            order.LaborCost = (order.Area * LaborCostPerSquareFoot);
            order.Tax = ((order.MaterialCost + order.LaborCost) * (TaxRate / 100));
            order.Total = (order.MaterialCost + order.LaborCost + order.Tax);

            response.Order = _orderRepository.Update(order);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Something went wrong";
            }
            else
            {
                response.Success = true;
            }
            return response;


        }

        public RemoveOrderResponse RemoveOrder(DateTime orderDate, int orderNumber)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.Order = _orderRepository.Delete(orderDate, orderNumber);
            if (response == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} is not a valid order.";
            }
            else
            {
                response.Success = true;
            }
            return response;

        }
    }
        
}
