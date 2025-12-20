//Exercise 1 pętle c#
//
// string password;
// do
// {Console.WriteLine("Wpisz haslo");
//     password = Console.ReadLine();
// } while (password != "admin123");
//
//
//Exercise 2: Poproś użytkownika o podanie liczby większej od zera. Jeśli poda liczbę ujemną
//lub 0 — zapytaj ponownie
 // int number;
 //
 // do
 // {
 //     Console.WriteLine("Wpisz liczbę większą od zera");
 //     number = Convert.ToInt32(Console.ReadLine());
 // }
 // while (number <= 0);
 //Zadanie 3: Utwórz tablicę z 5 nazwami miast i wypisz każde miasto w osobnej linii.
 //
 // string[] Cities = {"Poznan", "Warszawa", "Wroclaw", "Szczecin", "Gdansk"};
 // foreach ( string city in Cities)
 // {
 //     Console.WriteLine($"Miasto: {city}");
 // }
 //
 //Zadanie Domowe
 
 // Example 1
//Np. Osoby, które mają 14 lat mają dostęp do sklepu, ale nie mogą kupić i
//zarejestrować karty SIM
 // const int requiredAge = 18;
 // const int minRequiredAge = 14;
 // const string accessDeniedMessage = "Musisz mieć 18 lat!";
 // const string accessAllowedMessage = "Witamy w naszym sklepie!";
 // const string over14AllowedMessage = "Witamy w naszym sklepie, nie mozesz kupić karty sim!!";
 //
 //
 // int age = 18;
 //
 // do
 // {
 //     Console.Write("Podaj swój wiek: ");
 //     var userInput = Console.ReadLine();
 //
 //    
 //     var success = int.TryParse(userInput, out age);
 //
 //     if (!success)
 //     {
 //         Console.WriteLine("Musisz wprowadzić poprawną wartość!");
 //         continue;
 //     }
 //    
 //
 //     if (age >= requiredAge)
 //     {
 //         Console.WriteLine(accessAllowedMessage);
 //     }
 //     else if (age >= minRequiredAge)
 //     {
 //         Console.WriteLine(over14AllowedMessage);
 //     }
 //     else
 //     {
 //         Console.WriteLine(accessDeniedMessage);
 //     }
 // } while (age < requiredAge);
 //
 // Console.WriteLine("Exit...");
 //Zadanie 4: Utwórz klasę Osoba z polami Imie, Wiek i metodą PrzedstawSie(). Utwórz kilka
 // obiektów i wywołaj tę metodę.
//
//  class Osoba
//  {
//      public string imie;
//      public string nazwisko;
//      public int wiek;
//
//      public void przedstawSie()
//      {
//          Console.WriteLine($"Cześć, jestem {imie} {nazwisko} i mam {wiek} lat");
//      }
//
//  };
// class Program{
//     static void Main()
//     {
//         Osoba osoba = new Osoba();
//         Console.WriteLine("Podaj imie");
//         osoba.imie = Console.ReadLine();
//         Console.WriteLine("Podaj nazwisko");
//         osoba.nazwisko = Console.ReadLine();
//         Console.WriteLine("Podaj wiek");
//         string inputWiek = Console.ReadLine();
//         var success = int.TryParse(inputWiek, out osoba.wiek);
//         if (!success)
//         {
//             Console.WriteLine("Musisz wprowadzić poprawną wartość!");
//         }
//         else
//         {
//             osoba.przedstawSie();
//         }
//     }
// };
//Zadanie6.
// class Animal
// { 
//  public void Eat() => Console.WriteLine("Animal is eating");
// }
// class Cat : Animal
// {
// public void Meow()=> Console.WriteLine("Cat is meowing");
// }