// See https://aka.ms/new-console-template for more information


// MenuItem class representing the attributes of an individual menu item
public class MenuItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Vegetarian { get; set; }
    public double Price { get; set; }

    public MenuItem(string name, string description, bool vegetarian, double price)
    {
        Name = name;
        Description = description;
        Vegetarian = vegetarian;
        Price = price;
    }
}

// Menu interface representing a collection of menu items
public interface Menu : IEnumerable<MenuItem>
{
    // Interface method to add menu items
    void AddItem(string name, string description, bool vegetarian, double price);
}

// Concrete implementation of the Menu interface for PancakeHouseMenu
public class PancakeHouseMenu : Menu
{
    private List<MenuItem> menuItems;

    public PancakeHouseMenu()
    {
        menuItems = new List<MenuItem>();

        // Adding menu items
        AddItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs, and toast", true, 2.99);
        AddItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99);
        AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries, and blueberry syrup", true, 3.49);
        AddItem("Waffles", "Waffles, with your choice of blueberries or strawberries", true, 3.59);
    }

    // Implementation of the interface method to add menu items
    public void AddItem(string name, string description, bool vegetarian, double price)
    {
        MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
        menuItems.Add(menuItem);
    }

    // Implementation of the IEnumerable interface
    public IEnumerator<MenuItem> GetEnumerator()
    {
        foreach (MenuItem item in menuItems)
        {
            yield return item;
        }
    }

    // interface implementation for non-generic IEnumerable
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Concrete implementation of the Menu interface for DinerMenu
public class DinerMenu : Menu
{
    private const int MAX_ITEMS = 6;
    private int numberOfItems = 0;
    private MenuItem[] menuItems;

    public DinerMenu()
    {
        menuItems = new MenuItem[MAX_ITEMS];

        // Adding menu items
        AddItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
        AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
        AddItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29);
        AddItem("Hotdog", "A hot dog, with saurkraut, relish, onions, topped with cheese", false, 3.05);
        AddItem("Steamed Veggies and Brown Rice", "Steamed vegetables over brown rice", true, 3.99);
        AddItem("Pasta", "Spaghetti with Marinara Sauce, and a slice of sourdough bread", true, 3.89);
    }

    // Implementation of the interface method to add menu items
    public void AddItem(string name, string description, bool vegetarian, double price)
    {
        MenuItem menuItem = new MenuItem(name, description, vegetarian, price);

        if (numberOfItems < MAX_ITEMS)
        {
            menuItems[numberOfItems] = menuItem;
            numberOfItems++;
        }
        else
        {
            Console.WriteLine("Sorry, menu filled to capacity! Cannot add new item: " + name);
        }
    }

    // Implementation of the IEnumerable interface
    public IEnumerator<MenuItem> GetEnumerator()
    {
        foreach (MenuItem item in menuItems)
        {
            if (item != null)
            {
                yield return item;
            }
        }
    }

    // Explicit interface implementation for non-generic IEnumerable
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Client code to see the menu
class Program
{
    static void Main()
    {
        // Create a PancakeHouseMenu
        Menu pancakeHouseMenu = new PancakeHouseMenu();

        // Create a DinerMenu
        Menu dinerMenu = new DinerMenu();

        // Display the combined menu
        Console.WriteLine("MENU");
        Console.WriteLine("----");

        // Print breakfast items from PancakeHouseMenu
        Console.WriteLine("BREAKFAST");
        PrintMenuItems(pancakeHouseMenu);

        // Print lunch items from DinerMenu
        Console.WriteLine("LUNCH");
        PrintMenuItems(dinerMenu);
    }

    // Helper method to print menu items
    static void PrintMenuItems(Menu menu)
    {
        foreach (MenuItem item in menu)
        {
            Console.WriteLine($"{item.Name}, {item.Price:C} -- {item.Description}");
            Console.WriteLine($"Vegetarian: {item.Vegetarian}");
        }
        Console.WriteLine();
    }
}

