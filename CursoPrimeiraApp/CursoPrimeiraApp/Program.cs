//Screen Sound

string messageWelcome = "Welcome to Screen Sound";
//List<string> listBands = new List<string>();
List<string> listBands = new List<string>{ "Coldplay", "Linkin Park"};

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
            Console.WriteLine("Você escolheu a opção " + optionNumber);
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
    listBands.Add(nameBand);

    Console.WriteLine($"The band {nameBand} was register with succesfully");

    Thread.Sleep(2000);

    ShowOptionMenu();
}

void ShowRegisteredBands(){

    Console.Clear();

    ShowOptionTitle("Showing registered bands!");

    //for (int i = 0; i < listBands.Count; i++)
    //{
    //    Console.WriteLine($"Band: {listBands[i]}");
    //}

    foreach(string band in listBands) {
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

ShowOptionMenu();

