using System;
using System.Collections.Generic;

namespace Begino
{
    class Program
    {
		static List<string> SAPlist = new List<string>() {"Begino","Aquino","Estayan","Perez","Rizon"};
		
        static void Main(string[] args)
        {
			/*WILL ASK
			1. total monthly income
			2. how many members in the family
			3. is there a pwd or senior citizen
			4. surname and removing it upon inputed so that the looping will not read it
			thus printing an error output
			
			CONDITIONS to avail SAP
			1. there is a pwd or senior citizen
			2. monthly income < 10,000 and family members are greater or less than 4  
			
			CONDITIONS to avail 8,000 SAP 
			1. there is a senior citizen or pwd 
			if not qualified for 8,000 SAP, give 1,000 for each member of the family
			but not greater than 4,000
			
			4 P's members will have a discounted SAP*/
			
			int SAP;
			
			OpeningStatement();
			
			string UserInput1 = GetUserInput();
			string UserInput = UserInput1.ToUpper();
			
			while(UserInput != "N") //looping statement
			{
				Console.WriteLine("\n*****************************************************");
				Console.WriteLine("We will be needing your surname to avoid repetition of claiming.");
				Console.WriteLine("                     Thank You!");
				Console.WriteLine("*****************************************************");
				Console.WriteLine("\nEnter your surname:");
				string surname = Console.ReadLine();
				
				if(SurnameChecking(surname)) // conditional statement
				{
					SAPlist.Remove(surname);
					Console.WriteLine("\n*****************************************************");
					Console.WriteLine("                   Surname Found!");
					Console.WriteLine("            Proceed to answer all questions.");
					Console.WriteLine("*****************************************************");
					
					int UserInputFam = AskHowManyFamilyMembers();
					int UserInputIncome = AskHowMuchMonthlyIncome();
					char UserInputSeniorPwd = char.ToUpper(AskIsThereASeniorOrPwd());
					char UserInputFourPsMember = char.ToUpper(AskIf4PsMember());
				
					if(UserInputSeniorPwd != 'Y'&& UserInputSeniorPwd !='N') //conditional statement
					{
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("       !!!Invalid Entry. Please try again!!!");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
						
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
						
					if(UserInputSeniorPwd == 'N' && UserInputIncome >= 10000)//conditional statement
					{
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("         You are NOT QUALIFIED to recieve SAP.");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
					
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
					else if(UserInputSeniorPwd == 'N' && UserInputFourPsMember == 'Y' && UserInputFam <=4 && UserInputIncome<10000)//conditional statement
					{
						SAP = UserInputFam*1000;
						double DiscountedSAP = SAP*.1;
						double FinalDiscount = SAP-DiscountedSAP;
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("            You are QUALIFIED to recieve SAP.");
						Console.WriteLine(" But because you are a 4P's member, SAP is discounted.");
						Console.WriteLine("              You may recieve PHP "+FinalDiscount+".");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
					
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
					else if(UserInputSeniorPwd == 'N' && UserInputFourPsMember == 'Y' && UserInputFam >=5 && UserInputIncome<10000)//conditional statement
					{
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("            You are QUALIFIED to recieve SAP.");
						Console.WriteLine(" But because you are a 4P's member, SAP is discounted.");
						Console.WriteLine("              You may recieve PHP 3600.");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
					
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
					else if(UserInputSeniorPwd == 'N' && (UserInputFam <= 4 && UserInputIncome<10000))//conditional statement
					{
						SAP = UserInputFam*1000;
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("           You are QUALIFIED to recieve SAP.");
						Console.WriteLine("               You may recieve PHP "+SAP);
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
					
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
					else if(UserInputSeniorPwd == 'N' && (UserInputFam >= 4 && UserInputIncome<10000))//conditional statement
					{
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("           You are QUALIFIED to recieve SAP");
						Console.WriteLine("              You may recieve PHP 4,000");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
								
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
					else
					{
						Console.WriteLine("\n*****************************************************");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("          You are QUALIFIED to recieve SAP");
						Console.WriteLine("              You may recieve PHP 8,000");
						Console.WriteLine("*****************************************************");
						Console.WriteLine("*****************************************************\n\n");
					
						OpeningStatement();
						UserInput1 = GetUserInput();
						UserInput = UserInput1.ToUpper();
					}
				}
				else
				{
					Console.WriteLine("\n*****************************************************");
					Console.WriteLine("*****************************************************");
					Console.WriteLine("                    !!! ERROR !!!");
					Console.WriteLine("*****************************************************");
					Console.WriteLine("Oops! Looks like your surname is not on our list.");
					Console.WriteLine("                    Apologies :(");
					Console.WriteLine("*****************************************************");
					Console.WriteLine("*****************************************************\n\n");
				
					OpeningStatement();
					UserInput1 = GetUserInput();
					UserInput = UserInput1.ToUpper();
				}
			}
			Console.WriteLine("\n*****************************************************");
			Console.WriteLine("*****************************************************");
			Console.WriteLine("                !!!Program Closed!!!");
			Console.WriteLine("*****************************************************");
			Console.WriteLine("*****************************************************");
        }
		
		static void OpeningStatement() //method signature
		{
			Console.WriteLine("*****************************************************");
			Console.WriteLine("     !!!WELCOME TO AYUDA DISTRIBUTION PROGRAM!!!     ");
			Console.WriteLine("*****************************************************");
			Console.WriteLine("\nPresident Rodrigo Duterte has approved the distribution of cash assistance or Ayuda in the Philippines.");
			Console.WriteLine("This cash assistance is intended to alleviate the difficulties faced by residents who will be affected by the quarantine.");
			Console.WriteLine("\n*****************************************************");
			
			Console.WriteLine("\nEnter any key to proceed.");
			Console.WriteLine("Enter n to exit.");
		}
		
		static string GetUserInput() //method signature
		{
			Console.WriteLine("input:");
			string input = Console.ReadLine();
			return input;
		}
		
		static int AskHowManyFamilyMembers() //method signature
		{
			Console.WriteLine("\n************************************");
			Console.WriteLine("How many members of the family?");
			int fam = Convert.ToInt32(Console.ReadLine());
			return fam;
		}
		
		static int AskHowMuchMonthlyIncome() //method signature
		{
			Console.WriteLine("\n************************************");
			Console.WriteLine("Family Monthly Income: ");
			int inc = Convert.ToInt32(Console.ReadLine());
			return inc;
		}
		
		static char AskIsThereASeniorOrPwd() //method signature
		{
			Console.WriteLine("\n************************************");
			Console.WriteLine("Is there a PWD or senior citizen in the family?");
			char pwd1 = Console.ReadLine()[0];
			return pwd1;
		}
		
		static char AskIf4PsMember() //method signature
		{
			Console.WriteLine("\n************************************");
			Console.WriteLine("Is there a 4P's member in the family?");
			char FourPmember1 = Console.ReadLine()[0];
			return FourPmember1;
		}
		
		static bool SurnameChecking(string surname) //parameter
		{
			int found = SAPlist.IndexOf(surname);
			
			if (found == -1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
    }
}
