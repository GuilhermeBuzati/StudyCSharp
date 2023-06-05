//Screen Sound

string messageWelcome = "Welcome to Screen Sound";

//Creating dictionary
Dictionary<string, List<int>> dictBand = new Dictionary<string, List<int>>();

dictBand.Add("Link Park", new List<int> { 10, 9, 8 });
dictBand.Add("Foo Fighters", new List<int>());


void ShowMessageWelcome() {

    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░]

");
    Console.WriteLine(messageWelcome);

};

void ShowOptionMenu() {

    Console.Clear();
    ShowMessageWelcome();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    //.Write não pula linha ao finalizar linha.
    Console.Write("\nDigite sua opção: ");
    string option = Console.ReadLine()!;

    int optionNumber = int.Parse(option);

    //if(optionNumber == 1){
    //    Console.WriteLine("Você digitou a opção " + option);

    //}else if (optionNumber == 2){
    //    Console.WriteLine("Você digitou a opção " + option);

    //}

    switch (optionNumber)
    {
        case 1:
            CreateBand();
            break;
        case 2:
            ShowRegisteredBands();
            break;
        case 3:
            RatingBand();
            break;
        case 4:
            Console.WriteLine("Você escolheu a opção " + optionNumber);
            break;
        case -1:
            Console.WriteLine("Goodbye =)");
            break;

        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void CreateBand()
{
    Console.Clear();
    ShowOptionTitle("Band record");
    Console.Write("Write the name of the band you want to record: ");
    string nameBand = Console.ReadLine()!;
    dictBand.Add(nameBand, new List<int>());

    Console.WriteLine($"The band {nameBand} was register with succesfully");

    Thread.Sleep(2000);

    ShowOptionMenu();
}

void ShowRegisteredBands(){

    Console.Clear();

    ShowOptionTitle("Showing registered bands!");

    foreach(string band in dictBand.Keys) {
        Console.WriteLine($"Band: {band}");
    }

    Console.WriteLine("\nPress any key to return at main menu!");
    //ReadKey = Press any key to return at main menu
    Console.ReadKey();
    ShowOptionMenu();

}   

void ShowOptionTitle(string title)
{
    int quantityLetters = title.Length;

    string asterisks = string.Empty.PadLeft(quantityLetters, '*');

    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine(asterisks + "\n");
}

void RatingBand()
{
    Console.Clear();
    ShowOptionTitle("Rate band");

    Console.Write("Write the name of the band you want to rate: ");
    string nameBand = Console.ReadLine();

    if(dictBand.ContainsKey(nameBand))
    {

    }
    else
    {
        Console.WriteLine($"The band {nameBand} not exists!");
        Console.WriteLine("Press any key to return at main menu");
        Console.ReadKey();
        ShowOptionMenu();

    }
}

ShowOptionMenu();

