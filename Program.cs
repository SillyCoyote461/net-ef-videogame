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
        $"SEARCH -> Cerca gioco o lista giochi di una software house per ID. {nl}" +
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

            var vgList = context.Videogames
                .Where(v => v.Name.Contains(cmd))
                .ToList();

            Console.WriteLine(line);
            foreach (var v in vgList)
            {
                Console.WriteLine(v);
                Console.WriteLine(line);
            }
            
            break;

        //SEARCH GAME
        case "search":
            Console.WriteLine("Cosa vuoi cercare? (videogame / software house)");
            cmd = Console.ReadLine();
            if (cmd == "videogame")
            {
                Console.Write("Inserisci ID gioco: ");
                var idSearch = long.Parse( Console.ReadLine() );
                var vg = context.Videogames
                    .Where(v => v.Id == idSearch)
                    .FirstOrDefault();
                Console.WriteLine(vg);
            }
            else if (cmd == "software house")
            {
                Console.Write("Inserisci ID software house: ");
                var idHouse = long.Parse( Console.ReadLine() );
                var vg = context.Videogames
                    .Where (v => v.SoftwareHouseId == idHouse)
                    .ToList();
                Console.WriteLine(line);
                foreach ( var v in vg)
                {
                    Console.WriteLine(v);
                    Console.WriteLine(line);
                }
            }

            break;

        //ADD GAME OR SOFTWARE HOUSE
        case "add":
            Console.WriteLine("Cosa vuoi aggiungere? (videogame / software house)");
            cmd = Console.ReadLine();
            if(cmd == "videogame")
            {
                var vg = new Videogame();

                Console.Write(
                $"{line}{nl}" +
                $"Inserisci nome gioco: ");
                vg.Name = Console.ReadLine() ?? "";

                Console.Write($"Inserisci descrizione gioco: ");
                vg.Overview = Console.ReadLine() ?? "";

                Console.Write("Inserisci Id della software house: ");
                vg.SoftwareHouseId = Convert.ToInt64(Console.ReadLine());
                vg.Release_Date = DateTime.Now;

                context.Videogames.Add( vg );
                context.SaveChanges();

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
            $"Inserisci ID gioco: ");
            long id = Convert.ToInt64(Console.ReadLine());

            context.Remove(context.Videogames
                    .Where(v => v.Id == id)
                    .FirstOrDefault());
            context.SaveChanges();
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