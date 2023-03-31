using System.Data;
using System.Data.SqlClient;

namespace ConsoleShop
{
    internal class Program
    {



        static void register()
        {
            SqlConnection conn = new SqlConnection("workstation id=application.mssql.somee.com;packet size=4096;user id=app_SQLLogin_1;pwd=yespassword;data source=application.mssql.somee.com;persist security info=False;initial catalog=application");
            conn.Open();

            string loginn, fName, lName, password, phoneNumber, description, country, city, street;
            Console.Write("Login:");
            loginn = Console.ReadLine();


            SqlCommand islogin = new SqlCommand();
            islogin.Connection = conn;
            islogin.CommandText = string.Format("select count(*) from [user] where login = '{0}'", loginn);


            //liczba kolumn
            SqlDataReader reader2 = islogin.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    while ((int)reader2[0] > 0)
                    {
                        Console.WriteLine("login already taken, try again");
                        Console.Write("Login:");
                        loginn = Console.ReadLine();
                    }

                }
            }
            reader2.Close();


            Console.Write("First name:");
            fName = Console.ReadLine();
            Console.Write("Last name:");
            lName = Console.ReadLine();
            Console.Write("Password:");
            password = Console.ReadLine();
            Console.Write("Phone number:");
            phoneNumber = Console.ReadLine();
            Console.Write("Description(not required so you can leave empty):");
            description = Console.ReadLine();
            Console.Write("Country:");
            country = Console.ReadLine();
            Console.Write("City:");
            city = Console.ReadLine();
            Console.Write("Street:");
            street = Console.ReadLine();
            country = country.ToLower();
            city = city.ToLower();
            street = street.ToLower();



            SqlCommand register;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = string.Format("insert into[user](first_name, last_name, login, password, phone_number, description, country, city, street)values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", fName, lName, loginn, password, phoneNumber, description, country, city, street);
            register = new SqlCommand(sql, conn);
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();

        }
        //Tu nad loginem popracowac
        static void login()
        {
            string loginn, password;
            Console.Write("Login:");
            loginn = Console.ReadLine();
            Console.Write("Password:");
            password = Console.ReadLine();

            SqlConnection conn = new SqlConnection("workstation id=application.mssql.somee.com;packet size=4096;user id=app_SQLLogin_1;pwd=yespassword;data source=application.mssql.somee.com;persist security info=False;initial catalog=application");
            conn.Open();



            //selectowanie wszystkiego z wybranej tabeli i schemy
            SqlCommand login = new SqlCommand();
            login.Connection = conn;
            login.CommandText = string.Format("select id from [user] where login = '{0}' AND password = '{1}'", loginn, password);


            //liczba kolumn
            SqlDataReader reader2 = login.ExecuteReader();
            int numberOfColumns = reader2.FieldCount;

            //nazwy kolumn
            DataTable schemaTable = reader2.GetSchemaTable();
            string[] columnNames = new string[numberOfColumns];
            for (int i = 0; i < numberOfColumns; i++)
            {
                columnNames[i] = reader2.GetName(i);
            }




            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    for (int i = 0; i < numberOfColumns; i++)
                    {
                        Console.Write(columnNames[i]);
                        Console.Write(": ");
                        Console.WriteLine(reader2[i]);
                    }
                    Console.WriteLine();

                }
            }
            conn.Close();
            //end of select
        }

        static void search()
        {
            Console.Write("search:");
        }

        static void addListing()
        {
            string Name, photoPath;
            int price;
            Console.WriteLine("New Listing");
            Console.Write("Name:");
            Name = Console.ReadLine();

        }

        static int cantThinkOfANameRn(string[] text)
        {


            int pos = 0;
            int txtsum;
            while (true)
            {
                Console.Clear();
                int spcnum = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Console.Write("   ");
                }

                for (int i = 0; i < pos; i++)
                {
                    spcnum += text[i].Length + 3;
                }
                Console.WriteLine();

                for (int i = 0; i < spcnum; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("^");

                if (pos >= text.Length)
                    pos--;
                else if (pos < 0)
                    pos++;
                else
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.RightArrow:
                            pos++;
                            break;
                        case ConsoleKey.LeftArrow:
                            pos--;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            return pos;
                            Thread.Sleep(5000);
                            Console.Clear();
                            break;
                    }
            }
        }


        static void Main(string[] args)
        {
            Boolean isLoggedIn = false;
            int userid;
            string[] myAcc = new string[] { "Login", "Register" };
            string[] hub = new string[] { "Search", "My account", "Add listing" };
            switch (cantThinkOfANameRn(hub))
            {
                case 0:
                    search();
                    break;

                case 1:
                    if (cantThinkOfANameRn(myAcc) == 0)
                        login();
                    else
                        register();
                    isLoggedIn = true;
                    break;

                case 2:
                    if (isLoggedIn)
                        addListing();
                    else
                    {
                        Console.WriteLine("You need to create a new account first or login");


                        if (cantThinkOfANameRn(myAcc) == 0)
                            login();
                        else
                            register();
                        isLoggedIn = true;


                    }
                    break;
            }



        }
    }
}