using Microsoft.EntityFrameworkCore;
using Semaine_3___LINQ_EF.Models;
internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Test mode ? (enter 1 or 0)");
        string isTestMode = Console.ReadLine();

        bool testMode = isTestMode == "1";
        string exerciseSelected = "";
        string[] exercises = { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "C1", "C2", "D1", "D2", "E1", "E2", "E3", "E4" };

        while (true)
        {
            Console.WriteLine("\nPlease enter an exercise name between the following :\n");

            char lastChar = 'B';

            foreach (string exercise in exercises)
            {
                // Add break line between different exercises letters
                if (exercise[0] != lastChar) Console.WriteLine("\n");

                lastChar = exercise[0];

                Console.WriteLine(exercise);
            }

            Console.WriteLine("Type 'end' to end the program.");
            Console.WriteLine("Your choice : ");

            exerciseSelected = Console.ReadLine();

            if (exerciseSelected == "end")
            {
                Console.Clear();
                Console.WriteLine("Bye bye !");
                return;
            }

            if (!exercises.Contains(exerciseSelected))
            {
                Console.Clear();
                Console.WriteLine("No exercise found !");
                continue;
            }

            Console.Clear();

            switch (exerciseSelected)
            {
                case "B1":
                    {
                        ExB1(testMode);
                        break;
                    }
                case "B2":
                    {
                        ExB2();
                        break;
                    }
                case "B3":
                    {
                        ExB3();
                        break;
                    }
                case "B4":
                    {
                        ExB4(testMode);
                        break;
                    }
                case "B5":
                    {
                        ExB5();
                        break;
                    }
                case "B6":
                    {
                        ExB6();
                        break;
                    }
                case "B7":
                    {
                        ExB7();
                        break;
                    }
                case "C1":
                    {
                        ExC1();
                        break;
                    }
                case "C2":
                    {
                        ExC2();
                        break;
                    }
                case "D1":
                    {
                        ExD1(testMode);
                        break;
                    }
                case "D2":
                    {
                        ExD2();
                        break;
                    }
                case "E1":
                    {
                        ExE1(testMode);
                        break;
                    }
                case "E2":
                    {
                        ExE2();
                        break;
                    }
                case "E3":
                    {
                        ExE3();
                        break;
                    }
                case "E4":
                    {
                        ExE4();
                        break;
                    }
            }
        }

    }

    private static void GetProducts(NorthwindContext context, string categoryName)
    {
        Console.WriteLine("\nCategory : {0}\n", categoryName);
        var products = context.Products
            .Where(p => p.Category.CategoryName == categoryName)
            .Select(p =>  p.ProductName).ToArray();

        foreach (var productName in products)
        {
            Console.WriteLine(productName);
        }
    }

    private static void GetProductsEagerLoading(NorthwindContext context, string categoryName)
    {
        Console.WriteLine("\nCategory : {0}\n", categoryName);
        var products = context.Products.Include("Category")
            .Where(p => p.Category.CategoryName == categoryName)
            .Select(p => p.ProductName).ToArray();

        foreach (var productName in products)
        {
            Console.WriteLine(productName);
        }
    }

    private static void ExB1(bool testMode)
    {
        /// Exercice B1

        Console.WriteLine("\nEXERCICE B1\n");

        using (NorthwindContext context = new NorthwindContext())
        {
            string? cityName = null;
            Console.WriteLine("Enter a city name : ");
            if (testMode)
            {
                /// cityName is defined automatically

                cityName = "Bruxelles";
                Console.WriteLine(cityName);
            }
            else
            {
                /// cityName is defined manually

                var cities = context.Customers.Select(c => c.City).Distinct().ToList();

                Console.WriteLine("Exisiting cities :");
                foreach (var city in cities)
                {
                    Console.WriteLine(city);
                }
                cityName = Console.ReadLine() ?? "";
            }

            var customersInCity = context.Customers
                .Where(c => c.City == cityName)
                .Select(c => c.ContactName).ToArray();

            int customersCount = customersInCity.Count();

            if (customersCount == 0)
            {
                Console.WriteLine("No customer found in city {0}", cityName);
            }
            else
            {
                Console.WriteLine("{0} customer(s) found.", customersCount);
                foreach (var customerName in customersInCity)
                {
                    Console.WriteLine(customerName);
                }
            }
        }
    }

    private static void ExB2()
    {
        /// Exercice B2

        Console.WriteLine("\nEXERCICE B2\n");

        string categoryBeverages = "Beverages";
        string categoryCondiments = "Condiments";

        using (NorthwindContext context = new NorthwindContext())
        {
            GetProducts(context, categoryBeverages);
            GetProducts(context, categoryCondiments);
        }
    }

    private static void ExB3()
    {
        /// Exercice B3

        using (NorthwindContext context = new NorthwindContext())
        {
            /*
            Console.WriteLine("\nEXERCICE B3\n");
            GetProductsEagerLoading(context, categoryBeverages);
            GetProductsEagerLoading(context, categoryCondiments);
            */
        }
    }

    private static void ExB4(bool testMode)
    {
        /// Exercice B4

        Console.WriteLine("\nEXERCICE B4\n");

        using (NorthwindContext context = new NorthwindContext())
        {

            string? customerId = null;
            Console.WriteLine("Enter a customer id : ");
            if (testMode)
            {
                /// customerId is defined automatically

                customerId = "LILAS";
                Console.WriteLine(customerId);
            }
            else
            {
                /// customerId is defined manually

                var customers = context.Customers.Select(c => c.ContactName).ToList();

                Console.WriteLine("Exisiting customers :");
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
                customerId = Console.ReadLine() ?? "";
            }

            var orders = context.Orders
            .Where(o => o.CustomerId == customerId && o.ShippedDate != null)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new
            {
                o.CustomerId,
                o.OrderDate,
                o.ShippedDate
            }).ToArray();

            int ordersCount = orders.Count();

            if (ordersCount == 0)
            {
                Console.WriteLine("No order found for customer id {0}", customerId);
            }
            else
            {
                Console.WriteLine("{0} order(s) found.", ordersCount);
                foreach (var order in orders)
                {
                    Console.WriteLine("CustomerId : {0} ; OrderDate : {1} ; ShippedDate : {2}", order.CustomerId, order.OrderDate, order.ShippedDate);
                }
            }
        }
    }

    private static void ExB5()
    {
        /// Exercice B5

        Console.WriteLine("\nEXERCICE B5\n");

        using (NorthwindContext context = new NorthwindContext())
        {
            var productsTotalSales = context.OrderDetails
            .GroupBy(od => od.ProductId)
            .OrderBy(gp => gp.Key)
            .Select(gp => new { ProductId = gp.Key, TotalSales = gp.Sum(od => od.Quantity * od.UnitPrice) });

            foreach (var sales in productsTotalSales)
            {
                Console.WriteLine("{0} ----> {1}", sales.ProductId, sales.TotalSales);
            }
        }
    }

    private static void ExB6()
    {
        /// Exercice B6

        Console.WriteLine("\nEXERCICE B6\n");

        using (NorthwindContext context = new NorthwindContext())
        {
            var employeesInWestern = context.Territories
            .Where(t => t.Region.RegionDescription == "Western")
            .SelectMany(t => t.Employees) // Aplatir la liste des employés
            .Select(e => e.FirstName + " " + e.LastName) // Sélectionner le nom complet
            .Distinct();

            foreach (var employee in employeesInWestern)
            {
                Console.WriteLine(employee);
            }
        }
    }

    private static void ExB7()
    {
        /// Exercice B7

        Console.WriteLine("\nEXERCICE B7\n");

        string suyamaFirstName = "Michael";
        string suyamaLastName = "Suyama";

        using (NorthwindContext context = new NorthwindContext())
        {
            var territoriesHandledBySM = context.Employees
            .Where(e => e.FirstName == suyamaFirstName && e.LastName == suyamaLastName)
            .Select(e => e.ReportsToNavigation)
            .SelectMany(e => e.Territories)
            .Select(t => t.TerritoryDescription);

            foreach (var territory in territoriesHandledBySM)
            {
                Console.WriteLine(territory);
            }
        }
    }

    private static void ExC1()
    {
        /// Exercice C1 

        Console.WriteLine("\nEXERCICE C1\n");

        using (NorthwindContext context = new NorthwindContext())
        {
            var customersToUpdate = context.Customers
            .Select(c => c);

            foreach (var customerToUpdate in customersToUpdate)
            {
                customerToUpdate.ContactName = customerToUpdate.ContactName.ToUpper();
            }

            context.SaveChanges();
        }
    }

    private static void ExC2()
    {
        /// Exercice C2

        Console.WriteLine("\nEXERCICE C2\n");

        using (NorthwindContext context = new NorthwindContext())
        {
            var customersUpdated = context.Customers.Select(c => c.ContactName);

            foreach (var customerUpdated in customersUpdated)
            {
                Console.WriteLine("Customer updated: {0}", customerUpdated);
            }
        }
    }

    private static void ExD1(bool testMode)
    {
        /// Exercice D1

        Console.WriteLine("\nEXERCICE D1\n");

        string? categoryName = null;
        Console.WriteLine("Enter a category name : ");
        if (testMode)
        {
            /// categoryName is defined automatically

            categoryName = "Categoriiiieeee";
            Console.WriteLine(categoryName);
        }
        else
        {
            /// categoryName is defined manually

            categoryName = Console.ReadLine() ?? "";
        }

        using (NorthwindContext context = new NorthwindContext())
        {
            Category? categoryFound = context.Categories.Where(c => c.CategoryName == categoryName).FirstOrDefault();

            if (categoryFound != null)
            {
                Console.WriteLine("Catégorie déjà existante !");
            }
            else
            {
                Category newCategory = new Category { CategoryName = categoryName };

                context.Categories.Add(newCategory);

                context.SaveChanges();
            }

        }
    }

    private static void ExD2()
    {
        /// Exercice D2

        Console.WriteLine("\nEXERCICE D2\n");

        using (NorthwindContext context = new NorthwindContext())
        {

            var categories = context.Categories.Select(c => c.CategoryName);

            foreach (var category in categories)
            {
                Console.WriteLine("category name : {0}", category);
            }
        }
    }

    private static void ExE1(bool testMode)
    {
        /// Exercice E1

        Console.WriteLine("\nEXERCICE E1\n");

        string? categoryName = null;
        Console.WriteLine("Enter a category name : ");
        if (testMode)
        {
            /// categoryName is defined automatically

            categoryName = "Categoriiiieeee";
            Console.WriteLine(categoryName);
        }
        else
        {
            /// categoryName is defined manually

            categoryName = Console.ReadLine() ?? "";
        }

        using (NorthwindContext context = new NorthwindContext())
        {

            Category categoryToRemove = context.Categories.Where(c => c.CategoryName == categoryName).First<Category>();

            Console.WriteLine(categoryToRemove.CategoryName);
            Console.WriteLine(categoryToRemove.CategoryId);
            context.Categories.Remove(categoryToRemove);

            context.SaveChanges();
        }
    }

    private static void ExE2()
    {
        /// Exercice E2

        Console.WriteLine("\nEXERCICE E2\n");

        using (NorthwindContext context = new NorthwindContext())
        {

            var categoriesE1 = context.Categories.Select(c => c.CategoryName);

            foreach (var category in categoriesE1)
            {
                Console.WriteLine("category name : {0}", category);
            }
        }
    }

    private static void ExE3()
    {
        /// Exercice E3

        Console.WriteLine("\nEXERCICE E3\n");

        // employee DAVOLIO
        int employeeIdToDelete = 3;
        // employee FULLER 
        int employeeIdToUpdate = 4;

        using (NorthwindContext context = new NorthwindContext())
        {
            Employee? employeeToDelete = context.Employees.FirstOrDefault<Employee>(e => e.EmployeeId == employeeIdToDelete);
            Employee? employeeToUpdate = context.Employees.FirstOrDefault<Employee>(e => e.EmployeeId == employeeIdToUpdate);

            if (employeeToDelete == null)
            {
                Console.WriteLine("Employee to delete not found with id {0}", employeeIdToDelete);
                return;
            }

            if (employeeToUpdate == null)
            {
                Console.WriteLine("Employee to update not found with id {0}", employeeIdToUpdate);
                return;
            }

            IList<Order> ordersToAdd = employeeToDelete.Orders.ToList();

            foreach (var order in ordersToAdd)
            {
                employeeToUpdate.Orders.Add(order);
                employeeToDelete.Orders.Remove(order);
            }

            context.Territories.SelectMany(t => t.Employees).ToList().Remove(employeeToDelete);
            employeeToDelete.Territories.Clear();
            employeeToDelete.InverseReportsToNavigation.Clear();

            context.Employees.Remove(employeeToDelete);


            int countLineUpdated = context.SaveChanges();

            Console.WriteLine("{0} lines updated", countLineUpdated);
        }
    }

    private static void ExE4()
    {
        /// Exercice E4

        Console.WriteLine("\nEXERCICE E4\n");

        int employeeIdToUpdate = 4;

        using (NorthwindContext context = new NorthwindContext())
        {
            Employee employeeUpdated = context.Employees.First(e => e.EmployeeId == employeeIdToUpdate);

            foreach (Order order in employeeUpdated.Orders)
            {
                Console.WriteLine("Order id : {0} ; Employee id : {1}", order.OrderId, order.EmployeeId);
            }
        }
    }

}