
class Program
{
    static void Main(string[] args)
    {
        double n1=0, n2=0, ris=0;
    
        

        string risp2 = "no";


    

        bool continua=true;
   
        do
        {   Console.WriteLine("\nSeleziona operazione:");
            Console.WriteLine("1 - Somma");
            Console.WriteLine("2 - Sottrazione");
            Console.WriteLine("3 - Moltiplicazione");
            Console.WriteLine("4 - Divisione");
            Console.WriteLine("5 - Radice quadrata");
            Console.WriteLine("6 - Altre radici");
            Console.WriteLine("7 - Elevamento a potenza");
            
    
            ConsoleKeyInfo key=Console.ReadKey(true);
            string scelta=key.KeyChar.ToString();

        
            switch(scelta)
            {   
                
                    
                    case "1":    
                    label1:       
                    try{
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nPrimo numero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il primo numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }
                    
                        
                        Console.Write("Inserisci il secondo numero: ");
                        n2=double.Parse(Console.ReadLine()!);
                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label1;
                    }

                        
                        ris=n1+n2;
                        Console.WriteLine($"\n{n1.ToString("0.00")} + {n2.ToString("0.00")} = {ris.ToString("0.00")}");
                       
                        break;
                    
                    case "2":      
                    
                    label2:
                    try{
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nPrimo numero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il primo numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }


                        Console.Write("Inserisci il secondo numero: ");
                        n2=double.Parse(Console.ReadLine()!);
                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label2;
                    }
         
                        ris=n1-n2;
                        Console.WriteLine($"\n{n1.ToString("0.00")} - {n2.ToString("0.00")} = {ris.ToString("0.00")}");
                        break;

                    case "3": 
                    label3:
                    try{     
                    
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nPrimo numero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il primo numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }


                        Console.Write("Inserisci il secondo numero: ");
                        n2=double.Parse(Console.ReadLine()!);
                    
                    }

                    catch(Exception){
                    Console.WriteLine("Devi digitare un numero!");
                    goto label3;
                    }
  
                        ris=n1*n2;
                        Console.WriteLine($"\n{n1.ToString("0.00")} * {n2.ToString("0.00")} = {ris.ToString("0.00")}");
                        break;

                    case "4":   
                    label4:
                    try{   
                    
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nPrimo numero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il primo numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }
                    
                        //etichetta:

                        Console.Write("Inserisci il secondo numero: ");
                        n2=double.Parse(Console.ReadLine()!);
   
                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label4;
                    }
                        if(n2==0)
                        {
                            try
                            {
                                int nuovo_ris=Convert.ToInt32(n1)/Convert.ToInt32(n2);
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Non si può dividere per zero!");
                                goto label4;
                            }

                        }
                    
                    
                        
                        ris=n1/n2;
                        Console.WriteLine($"\n{n1.ToString("0.00")} / {n2.ToString("0.00")} = {ris.ToString("0.00")}");
                       //Console.WriteLine($"risultato: {ris}");
                        break;

                    case "5":
                    label5:
                    try{
                        riprova:
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nNumero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }

                        if(n1<0){
                        Console.WriteLine("I numeri negativi non ammettono radice. Riprova.");
                        risp2="no";
                        goto riprova;
                        }
                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label5;
                    }
                    
                        double rad=Math.Sqrt(n1);
                        ris=rad;
                        Console.WriteLine($"\nLa radice quadrata di {n1.ToString("0.00")} è {ris.ToString("0.00")}");
                        break;

                    case "6":
                    double grado;
                    label6:
                    try{
                        if(risp2=="si")
                        {
                            n1=ris;
                            Console.WriteLine($"\nNumero: {n1.ToString("0.00")}");
                        }
                        else
                        {
                            Console.Write("\nInserisci il numero: ");
                            n1=double.Parse(Console.ReadLine()!);
                        }

                        Console.Write("\nInserisci il grado della radice (es. cubica=3): ");
                        grado=double.Parse(Console.ReadLine()!);
                        while(grado<1){
                            Console.Write("\nIl grado della radice deve essere superiore allo 0!");
                            Console.Write("\nInserisci il grado della radice (es. cubica=3): ");
                            grado=double.Parse(Console.ReadLine()!);
                        }
                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label6;
                    }

                    if(n1<0){                                       //se il numero è negativo
                        if(grado%2==0){ 
                            while(n1<0) {                           //se l'esponente è pari
                             Console.Write("Non puoi trovare la radice con esponente pari di un numero negativo, digita un numero positivo: ");
                             n1=double.Parse(Console.ReadLine()!);
                            }
                        }
                        else{
                        n2=n1;                                      //altrimenti
                        n1=n1-n1-n1;
                        }
                    }

                        double esponente=1/grado;
                        Console.WriteLine($"Elevo alla: {grado}");
                        Console.WriteLine($"Esponente diventa: {esponente}");
                        ris = Math.Pow(n1, esponente); 
                
                        Console.Write($"\nLa radice ^{grado} di {n1.ToString("0.00")} è ");
                        if(n2<0){Console.Write("-");};
                        Console.WriteLine($"{ris.ToString("0.00")}");
                        break;

                    case "7":
                    label7:
                    int pot;
                    try{
                        if(risp2=="si")
                            {
                                n1=ris;
                                Console.WriteLine($"\nNumero da elevare: {n1.ToString("0.00")}");
                            }
                            else
                            {
                                Console.Write("\nInserisci il numero da elevare: ");
                                n1=double.Parse(Console.ReadLine()!);
                            }
                            double r=n1;

                            Console.Write("Inserisci la potenza: ");
                            pot=Int32.Parse(Console.ReadLine()!);

                    }
                    catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label7;
                    }
                        
                            /*for(int i=1;i<pot;i++)
                            {
                                r*=n1;
                            }*/
                        ris=Math.Pow(n1, pot);
                        Console.WriteLine($"\n{n1.ToString("0.00")} elevato alla ^{pot} = {ris.ToString("0.00")}");

                        break;


                    default:
                        Console.WriteLine("Selezione non valida.");
                        break;
                
            
            }                                                           
            selection:
            Console.Write("\nVuoi continuare? (si/no): ");
            string risp=Console.ReadLine()!;
            if(risp=="no"||risp=="si")
            {
                if(risp=="no")continua=false;
                else continua=true;
            }
            else{ Console.Write("Selezione non valida.\n");
                    goto selection;
            }
            

            if(continua)
            {   selection2:
                Console.Write($"\nVuoi tenere il risultato? ({ris.ToString("0.00")}) (si/no): ");
                risp2=Console.ReadLine()!;
                if(risp2!="no"&&risp2!="si")
                {   
                    Console.Write("Selezione non valida.\n");
                    goto selection2;
                }
            }
        }
        while(continua);

    }

    
}



/*
class Program
{
    static void Main(string[] args)
    {               
                    double n1=0;
                    double grado, ris;
                    int segno=1;

                    label6:
                    try{
                 
                        Console.Write("\nInserisci il numero: ");
                        n1=double.Parse(Console.ReadLine()!);
                        

                        Console.Write("\nInserisci il grado della radice (es. cubica=3): ");
                        grado=double.Parse(Console.ReadLine()!);
                        while(grado<1){
                            Console.Write("\nIl grado della radice deve essere superiore allo 0! Reinseriscilo: ");
                            grado=double.Parse(Console.ReadLine()!);
                        }

                        if(n1<0){
                            if(grado%2==0){
                                while(n1<0){
                                Console.Write("Non puoi trovare la radice con esponente pari di un numero negativo, digita un numero positivo: ");
                                n1=double.Parse(Console.ReadLine()!);
                                }
                            }
                            else{
                                n1=-(n1);
                                segno=-1;
                            }

                        }


                        double esponente=1/grado;
                        ris = Math.Pow(n1, esponente); 
                        n1=-(n1);
                        ris*=segno;
                
                        Console.Write($"\nLa radice ^{grado} di ");
                        Console.Write($"{n1.ToString("0.00")} è ");                      
                        Console.WriteLine($"{ris.ToString("0.00")}");
    
                        }catch(Exception){
                        Console.WriteLine("Devi digitare un numero!");
                        goto label6;
                    }
    }
    
}

*/