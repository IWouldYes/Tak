using System.Data.SqlClient;

namespace ConsoleApp9
{
    internal class Program
    {
        
        static void register()
        {
            string fName, lName, password, phoneNumber, description, country, city, street;
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

            SqlConnection conn = new SqlConnection("workstation id=application.mssql.somee.com;packet size=4096;user id=app_SQLLogin_1;pwd=yespassword;data source=application.mssql.somee.com;persist security info=False;initial catalog=application");
            conn.Open();

            SqlCommand register;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = string.Format("insert into[user](first_name, last_name, password, phone_number, description, country, city, street)values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", fName, lName, password, phoneNumber, description, country, city, street);
            register = new SqlCommand(sql, conn);
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            conn.Close();

        }

        static void login()
        {

        }


        static int cantThinkOfANameRn(string[] text)
        {
            
                Console.Clear();
                int pos = 0;
                int txtsum;
            while (true)
            {
                int spcnum = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Console.Write(" ");
                }
                Console.WriteLine(pos);
                for (int i = 0; i < pos; i++)
                {
                    spcnum += text[i].Length + 1;
                }
                Console.WriteLine(spcnum);

                for (int i = 0; i < spcnum; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("^");

                if (pos>=text.Length)
                    pos = 0;
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
            Boolean isLoggedIn;

            string[] tekst = new string[] { "option1", "option2", "option3", "option4" };
            register();
            Console.Write(cantThinkOfANameRn(tekst));
            


        }
    }
}