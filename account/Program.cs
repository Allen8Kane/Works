using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                
                Console.WriteLine("Вы хотите зарегистрироваться(1) или войти(0) или выйти(3): ");
                int.TryParse(Console.ReadLine(), out int flag);
                if (flag == 3)
                {
                    break;
                }
                while (flag == 1) {
                    User user = new User();

                    Console.WriteLine("Введите Имя и Фамилию: ");
                    while (true)
                    {
                        user.FullName = Console.ReadLine();
                        if (user.FullName.Length == 0) {
                            Console.WriteLine("Введите хотя бы один символ!");
                            Console.WriteLine("Введите Имя и Фамилию: ");
                        }
                        else {
                            break;
                        }
                    }
                    Console.WriteLine("Введите Возраст: ");
                    while (true)
                    {
                        int.TryParse(Console.ReadLine(), out int someNumber);
                        user.Age = someNumber;
                        if (user.Age < 0 || user.Age > 150)
                        {
                            Console.WriteLine("Некорректный возраст");
                            Console.WriteLine("Введите Возраст: ");
                        }
                        else
                        {
                            break;
                        }
                    }
                   
                    Console.WriteLine("Введите email: ");
                    while (true)
                    {
                        user.Email = Console.ReadLine();
                        int dogPosition = user.Email.IndexOf("@");
                        int dotPosition = user.Email.LastIndexOf(".");
                        if (dogPosition < dotPosition)
                        {
                            break;
                        }
                        Console.WriteLine("Некорректный email ");
                        Console.WriteLine("Введите email: ");
                    }
                    Console.WriteLine("Введите пароль: ");
                    while (true)
                    {
                        user.password = HidePassword.ReadPassword();
                        if (user.password.Length < 8)
                        {
                            Console.WriteLine("Минимальная длина пароля 8 символов");
                            Console.WriteLine("Введите пароль: ");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Введите номер (Формат : XXXXXXXXXXXX): ");
                    while (true)
                    {
                        user.Number = Console.ReadLine();
                        if (user.Number.Length < 11 || user.Number.Length > 11)
                        {
                            Console.WriteLine("номер должен быть одиннадцатизначным");
                            Console.WriteLine("Введите номер: ");
                        }
                        else {
                            break;
                        }
                    }

                    MemoryStream memoryStream = new MemoryStream();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    using (StreamWriter sw = new StreamWriter(@"c:\1\1.txt"))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, user);
                    }
                    break;
                }
                while (flag == 0)
                {
                    Console.WriteLine("Введите email: ");
                    string checkEmail = Console.ReadLine();
                    //string[] allFoundFiles = Directory.GetFiles("C:/1/", "1.txt", SearchOption.AllDirectories);
                   // Console.WriteLine(allFoundFiles[0]);
                    Console.WriteLine("Введите пароль: ");
                    string checkPassword = HidePassword.ReadPassword();

                    string json;
                    string path = @"c:\1\1.txt";
                    using (StreamReader sr = new StreamReader(path))
                    {
                        json = sr.ReadToEnd();
                    }


                   
                    if (item.Email != checkEmail && item.password != checkPassword)
                        {

                        }
                        else
                        {
                            break;
                        }
                    }
                }


            }
        }
    }
}
