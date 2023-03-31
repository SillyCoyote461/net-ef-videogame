using System.Data.SqlClient;

var nl = Environment.NewLine;
var line = $"-----------------------------";
bool execute = true;
var context = new VideogameContext();

while (execute)
{
    Console.WriteLine(
        $"Lista comandi: {nl}" +
        $"FILTER -> Ricerca giochi per nome.{nl}" +
        $"SEARCH -> Cerca gioco per ID. {nl}" +
        $"ADD ->  Aggiungi gioco o software house alla lista.{nl}" +
        $"DELETE -> Elimina gioco dalla lista.{nl}" +
        $"EXIT -> Chiudi il programma.");

    //INPUT
    Console.Write($"Digita il comando -> ");
    string cmd = Console.ReadLine() ?? "";

    //NO SPACES ALL LOWER
    cmd = cmd.Replace( " ", "" );
    cmd = cmd.ToLower();

    switch(cmd)
    {
        //FILTER GAMES
        case "filter":
            Console.Write(
            $"{line}{nl}" +
            $"Inserisci nome gioco: ");
            cmd = Console.ReadLine() ?? "";

            //foreach (var v in videogameList)
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine(line);
            break;

        //SEARCH GAME
        case "search":
            Console.Write(
                $"{line}{nl}" +
                $"Inserisci ID gioco: ");
            cmd = Console.ReadLine() ?? "";

            //Console.WriteLine($"{videogame}{nl}{line}");
            break;

        //ADD GAME
        case "add":
            Console.WriteLine("Cosa vuoi aggiungere? (videogame / software house)");
            cmd = Console.ReadLine();
            if(cmd == "videogame")
            {
                Console.Write(
                $"{line}{nl}" +
                $"Inserisci nome gioco: ");
                string name = Console.ReadLine() ?? "";
                Console.Write($"Inserisci descrizione gioco: ");
                string overview = Console.ReadLine() ?? "";
                Console.Write("Inserisci Id della software house: ");
                long softHouse = Convert.ToInt64(Console.ReadLine());
                var date = DateTime.Now;

            }
            else if(cmd == "software house")
            {
                var sh = new SoftwareHouse();
                Console.Write("Inserisci nome: ");
                sh.Name = Console.ReadLine();
                Console.Write("Inserisci nazione: ");
                sh.Country = Console.ReadLine();
                Console.Write("Inserisci cittá: ");
                sh.City = Console.ReadLine();
                Console.Write("Inserisci partita iva: ");
                sh.TaxId = Convert.ToInt64(Console.ReadLine());
                
                context.SoftwareHouse.Add( sh );
                context.SaveChanges();
            }
            Console.WriteLine(line);
            break;

        //DELETE GAME
        case "delete":
            Console.Write(
            $"{line}{nl}" +
            $"Inserisci nome gioco: ");
            long id = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(line);    
            break;

        //CLOSE PROGRAM
        case "exit":
            execute = false;
            break;

        default: 
            Console.WriteLine(
                $"{line}{nl}" +
                $"Comando '{cmd}' non riconosciuto. {nl}" +
                $"{line}{nl}");
            break;
    }   

}