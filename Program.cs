using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /* Challenge 1 */
        Console.WriteLine("Challenge 1: Find Common Elements in Jagged Array");
        int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
        int[] arr1Common = CommonItems(arr1);
        Console.WriteLine("Common Elements: " + string.Join(", ", arr1Common));
        Console.WriteLine();

        /* Challenge 2 */
        Console.WriteLine("Challenge 2: Inverse Jagged Array");
        int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        InverseJagged(arr2);
        Console.WriteLine("Inverse Jagged Array:");
        PrintJaggedArray(arr2);
        Console.WriteLine();

        /* Challenge 3 */
        Console.WriteLine("Challenge 3: Calculate Difference in Jagged Array");
        int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        CalculateDiff(arr3);
        Console.WriteLine("Difference in Jagged Array:");
        PrintJaggedArray(arr3);
        Console.WriteLine();

        /* Challenge 4 */
        Console.WriteLine("Challenge 4: Inverse Row/Column in Rectangular Array");
        int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] arr4Inverse = InverseRec(arr4);
        Console.WriteLine("Inverse Rectangular Array:");
        PrintRectangularArray(arr4Inverse);
        Console.WriteLine();

        /* Challenge 5 */
        Console.WriteLine("Challenge 5: Demo Function");
        Demo("hello", 1, 2, "world");
        Demo("My", 2, 3, "daughter", true, "is");
        Console.WriteLine();

        /* Challenge 6 */
        Console.WriteLine("Challenge 6: Swap Two Objects");
        SwapTwo();
        Console.WriteLine();

        /* Challenge 7 */
        Console.WriteLine("Challenge 7: Guessing Game");
        GuessingGame();
        Console.WriteLine();

        /* Challenge 8 */
        Console.WriteLine("Challenge 8: Product, OrderItem, Cart");
        var product1 = new Product(1, 30);
        var product2 = new Product(2, 50);
        var product3 = new Product(3, 40);
        var product4 = new Product(4, 35);
        var product5 = new Product(5, 75);

        var orderItem1 = new OrderItem(product1, 2);
        var orderItem2 = new OrderItem(product2, 1);
        var orderItem3 = new OrderItem(product3, 3);
        var orderItem4 = new OrderItem(product4, 2);
        var orderItem5 = new OrderItem(product5, 5);
        var orderItem6 = new OrderItem(product2, 2);

        var cart = new Cart();
        cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

        var firstItem = cart[0];
        Console.WriteLine("First Item in Cart: " + firstItem);

        int totalPrice, totalQuantity;
        cart.GetCartInfo(out totalPrice, out totalQuantity);
        Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

        var subCart = cart[1, 3];
        Console.WriteLine("Sub Cart: " + subCart);
    }
/* Challenge 1. Given a jagged array of integers (two dimensions).
    Find the common elements in the nested arrays. */
    static int[] CommonItems(int[][] jaggedArray)
    {
        HashSet<int> commonElements = new HashSet<int>(jaggedArray[0]);
        for (int i = 1; i < jaggedArray.Length; i++)
        {
            commonElements.IntersectWith(jaggedArray[i]);
        }
        return commonElements.ToArray();
    }

    /* Challenge 2. Inverse the elements of a jagged array. */
    static void InverseJagged(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Array.Reverse(jaggedArray[i]);
        }
    }

    /* Challenge 3. Find the difference between 2 consecutive elements of an array. */
    static void CalculateDiff(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 1; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = jaggedArray[i][j - 1] - jaggedArray[i][j];
            }
        }
    }

    /* Challenge 4. Inverse column/row of a rectangular array. */
    static int[,] InverseRec(int[,] recArray)
    {
        int rows = recArray.GetLength(0);
        int cols = recArray.GetLength(1);
        int[,] inverseArray = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                inverseArray[j, i] = recArray[i, j];
            }
        }

        return inverseArray;
    }

    /* Challenge 5. Write a function that accepts a variable number of params of any of these types: string, number. */
    static void Demo(params object[] items)
    {
        string sentence = "";
        int sum = 0;

        foreach (var item in items)
        {
            if (item is string str)
            {
                sentence += str + " ";
            }
            else if (item is int num)
            {
                sum += num;
            }
        }

        Console.WriteLine(sentence.Trim() + ";" + sum);
    }

    /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type. */
    static void SwapTwo()
    {
        object obj1 = "Hello";
        object obj2 = "World";

        if (obj1.GetType() == obj2.GetType())
        {
            if (obj1 is string str1 && obj2 is string str2)
            {
                if (str1.Length > 5 && str2.Length > 5)
                {
                    object temp = obj1;
                    obj1 = obj2;
                    obj2 = temp;
                }
            }
            else if (obj1 is int num1 && obj2 is int num2)
            {
                if (num1 > 18 && num2 > 18)
                {
                    object temp = obj1;
                    obj1 = obj2;
                    obj2 = temp;
                }
            }
        }

        Console.WriteLine(obj1);
        Console.WriteLine(obj2);
    }

    /* Challenge 7. Write a function that does the guessing game. */
    static void GuessingGame()
    {
        Random random = new Random();
        int targetNumber = random.Next(1, 101);
        int guess;

        do
        {
            Console.Write("Guess a number between 1 and 100: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out guess))
            {
                if (guess == targetNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                    break;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (true);
    }

    /* Helper method to print jagged array */
    static void PrintJaggedArray(int[][] jaggedArray)
    {
        foreach (var row in jaggedArray)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }

    /* Helper method to print rectangular array */
    static void PrintRectangularArray(int[,] recArray)
    {
        int rows = recArray.GetLength(0);
        int cols = recArray.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(recArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Price: {Price}, Quantity: {Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart = new List<OrderItem>();

    public OrderItem this[int index]
    {
        get { return _cart[index]; }
    }

    public Cart this[int startIndex, int endIndex]
    {
        get
        {
            Cart subCart = new Cart();
            for (int i = startIndex; i <= endIndex; i++)
            {
                subCart.AddToCart(_cart[i]);
            }
            return subCart;
        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        foreach (var item in items)
        {
            var existingItem = _cart.Find(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item);
            }
        }
    }

    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
        totalPrice = 0;
        totalQuantity = 0;
        foreach (var item in _cart)
        {
            totalPrice += item.Price * item.Quantity;
            totalQuantity += item.Quantity;
        }
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _cart);
    }
}