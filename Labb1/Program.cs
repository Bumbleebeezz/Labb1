/* 
    Be användaren om en sträng

    Deklarera en variabel som sparar inputen (inputText) , typ string
    Deklarera en variabel som sparar siffrorna (Number), typ string
    Deklarera en lista, typ list, som håller (Number)´s
    Deklarera en variabel, typ int (SumOfNumbers), som skriver ut summan

    Loppa igenom hela texten
        Om tecken är en siffra 
            lägga till den i en variabel
        annars 
            loppen ska breaka 
            lägga till (Number) -> (ListOfNumbers)
    
    Skriva ut hela strängen
        För varje delsträng hittad 
            markera delsträngarna på varsin rad

    För varje tal i (ListOfNumbers)
            Konvertera (ListOfNumber) till int
            Addera alla talen i (ListOfNumbers)
        Skriv ut (SumOfNumbers)

*/

// Be användaren om en sträng
Console.Write("Write a string: ");

// Deklarera en variabel som sparar inputen (inputString) , typ string
string inputString = Console.ReadLine();

// Deklarera en lista, typ list, som håller (Number)´s
List<string> ListOfNumbers = new();

// Deklarera en variabel, typ int (SumOfNumbers), som skriver ut summan
long SumOfNumbers  = 0;

// Loppa igenom hela texten
for (int i = 0; i < inputString.Length; i++)
{   
    // Deklarera en variabel som håller koll på antalet tecken i currentNumber
    int counter = 0;
    string currentNumber = string.Empty;
    // om vi skulle börja på bokstav gå till nästa element i arrayen
    if (Char.IsLetter(inputString[i])) continue;
    currentNumber += inputString[i];
    counter++;
    //kolla nästkommande element efter i tills bokstav eller matchande siffra
    for (int j = i + 1; j < inputString.Length; j++)
    {
        // om nästa tecken är en bokstav så är det slut och vi kan låta i gå till nästa tecken
        if (Char.IsLetter(inputString[j]))
        {
            // avsluta j loop
            break;
        }
        currentNumber += inputString[j];
        counter++;

        // Om counter är mer eller lika med 3
        if (counter >= 3) { 
        //Om nästa tecken vara samma så lägg till i arrayen och låt i gå vidare
            if (inputString[i] == inputString[j])
            {
                ListOfNumbers.Add(currentNumber);

                var beforeMatch = inputString.Substring(0, i);
                var afterMatch = inputString.Substring(j + 1, inputString.Length - j - 1);

                // Skriv ut string med highlighted nummer
                Console.Write(beforeMatch);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(currentNumber);
                Console.ResetColor();
                Console.Write(afterMatch);
                Console.WriteLine();

                break;
            }
        }
    }
}

for (int i = 0; i < ListOfNumbers.Count; i++) 
{
    long num = 0;
    bool isParsable = Int64.TryParse(ListOfNumbers[i], out num);
    // Addera num till SumOfNumbers
    SumOfNumbers += num;
}
// Skriv ut SumOfNumbers
Console.WriteLine($"Total = {SumOfNumbers}");