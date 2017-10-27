using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryPA1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankingAccountApp();

            List<string> Login = new List<string>();
            List<string> Banking = new List<string>();
            
            string loginSelection = LoginMenu(Login);

            BankingAccount account = new BankingAccount(null,null,0.0);

            if (loginSelection.Contains("(C)"))
            {
                Console.WriteLine();
                Console.CursorVisible = true;

                account = new BankingAccount();
            }
            else if (loginSelection.Contains("(L)"))
            {
                account = new BankingAccount("Lee","abc", 1000.00);                                
            }

            Console.WriteLine();
            Console.CursorVisible = true;

            bool success;
            do
            {
                success = Loggingin(account, Login, loginSelection);
            } while (success == false);

            Console.CursorVisible = true;
            ConsoleColor reset = Console.ForegroundColor;
            ConsoleColor warning = ConsoleColor.Red;

            string bankingSelection;
            do
            {
                bankingSelection = BankingMenu(Login, loginSelection, Banking);

                if (bankingSelection.Contains("(D)"))
                {
                    Console.CursorVisible = true;

                    int i = 0;
                    double value;
                    string responce = "";
                    List<string> warningText = new List<string>();
                    warningText.Add("Invalid, try again");

                    bool parsed;
                    do
                    {
                        do
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.Write("Enter Deposit Amount: $");

                            if (i > 0)
                            {
                                Console.CursorVisible = false;
                                Console.SetCursorPosition(0, 2);
                                System.Threading.Thread.Sleep(2000);
                                warningText[0].Replace(warningText[0], Print("                   "));
                                Console.SetCursorPosition(23, 3);
                                Console.CursorVisible = true;
                            }

                            responce = Console.ReadLine();
                        } while (responce == "");

                        parsed = double.TryParse(responce, out value);
                        if (parsed)
                        {
                            account.Deposit(value);
                        }
                        else
                        {
                            Console.Clear();

                            PrintMenus(Login, loginSelection, Banking, bankingSelection);
                            Console.WriteLine();

                            Console.ForegroundColor = warning;
                            Console.Write(warningText[0]);
                            Console.ForegroundColor = reset;
                            i++;
                        }
                    } while (parsed == false);
                }
                else if (bankingSelection.Contains("(W)"))
                {
                    Console.CursorVisible = true;

                    int i = 0;
                    double value;
                    string responce = "";
                    List<string> warningText = new List<string>();
                    warningText.Add("Invalid, try again");

                    bool parsed;
                    do
                    {
                        do
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.Write("Enter Withdraw Amount: $");

                            if (i > 0)
                            {
                                Console.CursorVisible = false;
                                Console.SetCursorPosition(0, 2);
                                System.Threading.Thread.Sleep(2000);
                                warningText[0].Replace(warningText[0], Print("                   "));
                                Console.SetCursorPosition(24, 3);
                                Console.CursorVisible = true;
                            }

                            responce = Console.ReadLine();
                        } while (responce == "");

                        parsed = double.TryParse(responce, out value);
                        if (parsed)
                        {
                            account.Withdraw(value);

                            if (account.Balance < 0 && value > 0)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = warning;
                                Console.Write("Over Draft Charge of $10");
                                Console.ForegroundColor = reset;
                                System.Threading.Thread.Sleep(2000);
                                account.Withdraw(10.00);
                            }
                        }
                        else
                        {
                            Console.Clear();

                            PrintMenus(Login, loginSelection, Banking, bankingSelection);
                            Console.WriteLine();

                            Console.ForegroundColor = warning;
                            Console.Write(warningText[0]);
                            Console.ForegroundColor = reset;
                            i++;
                        }
                    } while (parsed == false);
                }
                else if (bankingSelection.Contains("(B)"))
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine();
                    Console.Write(account.ToString());
                    System.Threading.Thread.Sleep(2000);
                }
            } while (!bankingSelection.Contains("(E)"));

            if (bankingSelection.Contains("(E)"))
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine();
                Console.Write(account.ToString());
                System.Threading.Thread.Sleep(2000);
            }
        }
        public static void BankingAccountApp()
        {
            Console.Title = "Banking Account Application";

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public static string LoginMenu(List<string> Login)
        {
            string highlight = "";
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            Login.Add("(C)reate a new account");
            Login.Add(" ");
            Login.Add("(L)ogin to an account");
            do
            {
                do
                {
                    Console.Clear();
                    highlight = Login[0].Replace(Login[0], Highlight(Login[0]));
                    Console.Write(Login[1]);
                    Console.Write(Login[2]);

                    key = Console.ReadKey(true);
                } while ((key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.L && key.Key != ConsoleKey.Enter));

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                do
                {
                    Console.Clear();
                    Console.Write(Login[0]);
                    Console.Write(Login[1]);
                    highlight = Login[2].Replace(Login[2], Highlight(Login[2]));

                    key = Console.ReadKey(true);
                } while ((key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.C && key.Key != ConsoleKey.Enter));
            } while (key.Key != ConsoleKey.Enter);
            return highlight;
        }
        public static bool Loggingin(BankingAccount account, List<string> Login, string selection, string username = "", string password = "")
        {
            do
            {
                Console.Clear();
                PrintMenus(Login, selection);

                Console.Write("Enter Username: ");
                username = Console.ReadLine();
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            } while (username == "" || password == "");

            bool[] validation = account.ValidatePassword(username,password);

            if (validation[0] == true && validation[1] == true)
            {
                return true;
            }
            else if ( validation[0] == true && validation[1] == false )
            {
                Console.WriteLine("invalid password, try again");
                Loggingin(account, Login, selection);
            }
            else if (validation[0] == false && validation[1] == true)
            {
                Console.WriteLine("invalid username, try again");
                Loggingin(account, Login, selection);
            }
            else if (validation[0] == false && validation[1] == false)
            {
                Console.WriteLine("invalid, try again");
                Loggingin(account, Login, selection);
            }
            return true;
        }
        public static string BankingMenu(List<string> Login, string loginSelection, List<string> Banking)
        {
            string highlight = "";
            int i = 0;
            int j = 0;

            Console.Clear();
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            Banking.Add("(D)eposit");
            Banking.Add(" ");
            Banking.Add("(W)ithdraw");
            Banking.Add(" ");
            Banking.Add("(B)alance");
            Banking.Add(" ");
            Banking.Add("(E)xit");

            PrintMenus(Login, loginSelection);

            highlight = Banking[0].Replace(Banking[0], Highlight(Banking[0]));
            Console.Write(Banking[1]);
            Console.Write(Banking[2]);
            Console.Write(Banking[3]);
            Console.Write(Banking[4]);
            Console.Write(Banking[5]);
            Console.Write(Banking[6]);
            
            do
            {                
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.RightArrow)
                {
                    j = j + 2;
                    i = i + 10;

                    if (j == 8)
                    {
                        j = 0;
                        i = 0;
                    }
                    else if (j == 4)
                    {
                        i = i + 1;
                    }

                    for (; i <= 80;)
                    {
                        Console.Clear();
                        PrintMenus(Login, loginSelection, Banking);

                        Console.SetCursorPosition(i, 1);

                        for (; j <= 6;)
                        {
                            highlight = Banking[j].Replace(Banking[j], Highlight(Banking[j]));

                            break;
                        }
                        break;
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    j = j - 2;
                    i = i - 10;

                    if (j == -2)
                    {
                        j = 6;
                        i = 31;
                    }
                    else if (j == 2)
                    {
                        i = i - 1;
                    }

                    for (; i >= 0;)
                    {
                        Console.Clear();
                        PrintMenus(Login, loginSelection, Banking);

                        Console.SetCursorPosition(i, 1);

                        for (; j >= 0;)
                        {
                            highlight = Banking[j].Replace(Banking[j], Highlight(Banking[j]));

                            break;
                        }
                        break;
                    }
                }
                if (key.Key == ConsoleKey.D)
                {
                    Console.Clear();
                    PrintMenus(Login, loginSelection, Banking, highlight = Banking[0]);
                    i = 0;
                    j = 0;
                }
                if (key.Key == ConsoleKey.W)
                {
                    Console.Clear();
                    PrintMenus(Login, loginSelection, Banking, highlight = Banking[2]);
                    i = 10;
                    j = 2;
                }
                if (key.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    PrintMenus(Login, loginSelection, Banking, highlight = Banking[4]);
                    i = 21;
                    j = 4;
                }
                if (key.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    PrintMenus(Login, loginSelection, Banking, highlight = Banking[6]);
                    i = 31;
                    j = 6;
                }
            } while (key.Key != ConsoleKey.Enter);
            return highlight;
        }
        static void PrintMenus(List<string> Login, string loginSelection, List<string> Banking = null, string bankingSelection2 = null)
        {
            if (loginSelection.Contains("(C)"))
            {
                loginSelection.Replace(loginSelection, Highlight(loginSelection));
                Console.Write(Login[1]);
                Console.Write(Login[2]);
                Console.WriteLine();
            }
            else if (loginSelection.Contains("(L)"))
            {
                Console.Write(Login[0]);
                Console.Write(Login[1]);
                loginSelection.Replace(loginSelection, Highlight(loginSelection));
                Console.WriteLine();
            }
            if(Banking != null && bankingSelection2 != null)
            {
                if(bankingSelection2.Contains("(D)"))
                {
                    bankingSelection2.Replace(bankingSelection2, Highlight(bankingSelection2));
                    Console.Write(Banking[1]);
                    Console.Write(Banking[2]);
                    Console.Write(Banking[3]);
                    Console.Write(Banking[4]);
                    Console.Write(Banking[5]);
                    Console.Write(Banking[6]);
                }
                else if(bankingSelection2.Contains("(W)"))
                {
                    Console.Write(Banking[0]);
                    Console.Write(Banking[1]);
                    bankingSelection2.Replace(bankingSelection2, Highlight(bankingSelection2));
                    Console.Write(Banking[3]);
                    Console.Write(Banking[4]);
                    Console.Write(Banking[5]);
                    Console.Write(Banking[6]);
                }
                else if (bankingSelection2.Contains("(B)"))
                {
                    Console.Write(Banking[0]);
                    Console.Write(Banking[1]);
                    Console.Write(Banking[2]);
                    Console.Write(Banking[3]);
                    bankingSelection2.Replace(bankingSelection2, Highlight(bankingSelection2));
                    Console.Write(Banking[5]);
                    Console.Write(Banking[6]);
                }
                else if (bankingSelection2.Contains("(E)"))
                {
                    Console.Write(Banking[0]);
                    Console.Write(Banking[1]);
                    Console.Write(Banking[2]);
                    Console.Write(Banking[3]);
                    Console.Write(Banking[4]);
                    Console.Write(Banking[5]);
                    bankingSelection2.Replace(bankingSelection2, Highlight(bankingSelection2));
                }
            }
            else if(Banking != null && bankingSelection2 == null)
            {
                Console.Write(Banking[0]);
                Console.Write(Banking[1]);
                Console.Write(Banking[2]);
                Console.Write(Banking[3]);
                Console.Write(Banking[4]);
                Console.Write(Banking[5]);
                Console.Write(Banking[6]);
            }
        }
        static string Highlight(string s)
        {
            ConsoleColor temp;  // declaring temporary consolecolor
            temp = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.BackgroundColor = temp;     // returns text to previous color
            return s;
        }
        static string Print(string s)
        {
            ConsoleColor temp;  // declaring temporary consolecolor
            temp = Console.BackgroundColor;

            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.BackgroundColor = temp;     // returns text to previous color
            return s;
        }
    }
}
