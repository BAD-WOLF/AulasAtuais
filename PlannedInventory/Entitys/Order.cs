namespace PlannedInventory.Entitys {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using PlannedInventory.Entitys.Enums;

    
    internal class Order {
        private DateTime _moment = DateTime.Now;
        private OrderStatus _orderStatus;
        private List<OrderItem> _items;
        private Client _client;

        public Order(Client client, OrderStatus orderStatus, List<OrderItem> orderItems) {
            this._orderStatus = orderStatus;
            this._items = orderItems;
            this._client = client;
        }

        internal void AddItem(OrderItem item) {
            this._items.Add(item);
        }

        internal void Remove(OrderItem item) {
            this._items.Remove(item);
        }

        internal Single Total() {
            Single total = 0;
            for( Int32 i = 0; i < this._items.Count; i++ ) {
                total += this._items[i].SubTotal();
            }
            return total;
        }

        public override String ToString() {
            StringBuilder sb = new StringBuilder();

            // Dados principais do pedido
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order moment: {this._moment:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Order status: {this._orderStatus}");
            sb.AppendLine($"Client: {this._client.Name} ({this._client.BirthDate:dd/MM/yyyy}) - {this._client.Email}");

            // Itens do pedido
            sb.AppendLine("Order items:");
            foreach( var item in this._items ) {
                sb.AppendLine($"{item.Product().Name}, ${item.Price:F2}, Quantity: {item.Quantity}, Subtotal: ${item.SubTotal():F2}");
            }

            // Preço total
            sb.AppendLine($"Total price: ${this.Total():F2}");

            return sb.ToString();
        }
    }
}
