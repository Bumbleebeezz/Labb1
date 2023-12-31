﻿// Be användaren om en sträng
Console.Write("Write a string: ");

// Deklarera en variabel av typ string som sparar inputen
string inputString = Console.ReadLine();

// Deklarera en lista, som håller de nummersträngar som har hittas
List<string> ListOfNumbers = new();

// Deklarera en variabel, typ long, som håller den totala summan av alla nummersträngar 
long SumOfNumbers  = 0;

// Loppa igenom varje tecken i (inputString)
for (int i = 0; i < inputString.Length; i++)
{   
    // Deklarera en variabel som håller det nuvarande nummersträngen, ska nollställas varje gång (i) ökar med 1
    string currentNumber = string.Empty;
    // Deklarera en variabel som håller koll på antalet tecken i (currentNumber) 
    int counter = 0;

    // Om (i) skulle börja på en siffra 
    if (Char.IsDigit(inputString[i])) 
    { 
        // Lägg till inputString[i] i (currentNumber)
        currentNumber += inputString[i];
        // Öka (counter) med 1
        counter++;
    }
    // Annars
    else 
    { 
        // Öka (i) med 1 och fortsätt
        continue;
    }

    //Kolla nästkommande tecken efter (i) tills bokstav hittas eller att inputString[i] är lika med inputString[j]
    for (int j = i + 1; j < inputString.Length; j++)
    {
        // Om (j) är en siffra 
        if (Char.IsDigit(inputString[j]))
        {
            // Lägg till tecknet i (currentNumber)
            currentNumber += inputString[j];
            // Öka (counter) med 1
            counter++;
        }
        // Annars 
        else 
        { 
            // Avbryt nuvarande (j) loop
            break;
        }

        // Om counter är mer eller lika med 3
        if (counter >= 3) { 
            // Om värdet på plats (i) är samma som värdet på plats (j)
            if (inputString[i] == inputString[j])
            {
                // Lägg till (currentNumber) i (ListOfNumbers)
                ListOfNumbers.Add(currentNumber);

                // Deklarera en variabel som innehåller en substräng från inputString[0] till inputString[i]
                var beforeMatch = inputString.Substring(0, i);
                // Deklarera en variabel som innehåller en subträng från inputString[j + 1] till sista tecknet i (inputString)
                var afterMatch = inputString.Substring(j + 1, inputString.Length - j - 1);

                // Skriv ut (beforeMatch)
                Console.Write(beforeMatch);
                // Ändra färgen för kommande utskrift
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Skriv ut (currentNumber)
                Console.Write(currentNumber);
                // Återställ färget till default
                Console.ResetColor();
                // Skriv ut (afterMatch)
                Console.Write(afterMatch);
                // Skapa en ny rad för nästkommande utskrift
                Console.WriteLine();

                // Avbryt nuvarande (i) loop
                break;
            }
        }
    }
}

// För varje item i (ListOfNumbers)
for (int i = 0; i < ListOfNumbers.Count; i++) 
{
    // Deklarera en variabel, typ long, som håller det konverterade nummersträngen, nollställs varje gång (i) ökar med 1
    long num = 0;
    // Om det går att konvertera nummersträngarna frånn string till int, spara värdet i (num)
    bool isParsable = Int64.TryParse(ListOfNumbers[i], out num);
    // Addera num till SumOfNumbers
    SumOfNumbers += num;
}
// Skriv ut SumOfNumbers
Console.WriteLine($"Total = {SumOfNumbers}");