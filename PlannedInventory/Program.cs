using PlannedInventory.Entitys;
using PlannedInventory.Entitys.Enums;

internal class Program {
    private static void Main(String[] args) {

        #region Client Instantiation Area
        String name;
        do {
            Console.Write("Client Name >> ");
        } while( !((name = Console.ReadLine() ?? String.Empty) != String.Empty) );

        String email;
        do {
            Console.Write("Client Email >> ");
        } while( !((email = Console.ReadLine() ?? String.Empty) != String.Empty) );

        DateOnly birthDate;
        do {
            Console.Write("Client BirthDate <dd/MM/yyyy> >> ");
        } while( !(DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out birthDate)) );

        Client client = new Client(name: name, email: email, birthDate: birthDate);
        #endregion

        #region OrderItems Instantiation Area
        List<OrderItem> orderItems = new List<OrderItem>();

        Int32 itemQuantity;
        do {
            Console.Write("Whats's Items Quantity: ");
        } while( !Int32.TryParse(Console.ReadLine(), out itemQuantity) );

        for( Int32 i = 0; i < itemQuantity; i++ ) {
            Console.WriteLine($"item #{i}");
            String nameItem;
            do {
                Console.Write("Name Of Item >> ");
            } while( !((nameItem = Console.ReadLine() ?? String.Empty) != String.Empty) );

            Single price;
            do {
                Console.Write("Price Of Item >>  ");
            } while( !Single.TryParse(Console.ReadLine(), out price) );

            Int32 quantity;
            do {
                Console.Write("Item Quantity To This Item >> ");
            } while( !Int32.TryParse(Console.ReadLine(), out quantity) );

            OrderItem orderItem = new OrderItem(nameItem, price, quantity);
            orderItems.Add(orderItem);
        }
        #endregion

        Order order = new Order(client, OrderStatus.PENDING_PAYMENT, orderItems);

        Console.WriteLine(order.ToJson());
    }
}