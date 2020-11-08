using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GroupsRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
           Random random = new Random();
           string[] firstfile = File.ReadAllLines(args[0]);
           string[] secondfile = File.ReadAllLines(args[1]);
           int ngroup = Int32.Parse(args[2]);
           int randnumb = 0;
           int randnumb1 = 0;
           int groupest = firstfile.Length / ngroup;
           bool condition = false;
           int residue = (firstfile.Length % ngroup);
           string[] ResidueArrayest = new string[residue];
           string[] ResidueArraytopic = new string[residue];
           int i;
           int cont = 0;

           if(firstfile.Length % ngroup != 0){
               condition = true;
               for(i = firstfile.Length - 1; i > firstfile.Length - residue - 1; i--){
                   ResidueArrayest[cont] = firstfile[i];
                   ResidueArraytopic[cont] = secondfile[i];
                   firstfile[i] = "Taked";
                   secondfile[i] = "Taked";
                   cont++;
               }
           } 

           if(firstfile.Length != secondfile.Length || ngroup > secondfile.Length ){
               
                Console.WriteLine("No se puede trabajar con los parametros dados");
               
           }
           else
           {

               Group[] groups =  new Group[ngroup];
               for(i = 0; i < ngroup; i++){
                   groups[i] = new Group();
               }

                while(firstfile.Any(student => student != "Taked")){
                    randnumb = random.Next(ngroup);
                    randnumb1 = random.Next(firstfile.Length);

                    if(firstfile[randnumb1] != "Taked" && secondfile[randnumb1] != "Taked" && groups[randnumb].Estudiantes.Count() != groupest && groups[randnumb].Topics.Count() !=  groupest){

                        groups[randnumb].Estudiantes.Add(firstfile[randnumb1]);
                        groups[randnumb].Topics.Add(secondfile[randnumb1]);
                        firstfile[randnumb1] = "Taked";
                        secondfile[randnumb1] = "Taked";
                    }
                }

                if(condition){
                    groupest = firstfile.Length / ngroup + 1;
                    while(ResidueArrayest.Any(student => student != "Taked"))
                    {
                        randnumb = random.Next(ngroup);
                        randnumb1 = random.Next(ResidueArrayest.Length);
                        if(ResidueArrayest[randnumb1] != "Taked" && ResidueArraytopic[randnumb1] != "Taked" && groups[randnumb].Estudiantes.Count() != groupest && groups[randnumb].Estudiantes.Count() != groupest){
                        groups[randnumb].Estudiantes.Add(ResidueArrayest[randnumb1]);
                        groups[randnumb].Topics.Add(ResidueArraytopic[randnumb1]);
                        ResidueArrayest[randnumb1] = "Taked";
                        ResidueArraytopic[randnumb1] = "Taked";

                        
                    }
                    condition = false;
                }
                cont = 1;
                for(i = 0; i<ngroup; i++)
                {

                Console.WriteLine($"Grupo {i + 1} (Estudiantes: {groups[i].Estudiantes.Count()}, Temas: {groups[i].Topics.Count()})");
                Console.WriteLine("Estudiantes:");
                foreach(string s in groups[i].Estudiantes){
                    Console.WriteLine($"{cont} - {s} ");
                    cont++;
                }    
                cont = 1;
                Console.WriteLine("     Temas:");
                foreach(string s in groups[i].Topics){
                    Console.WriteLine($"     {cont} - {s} ");
                    cont++;
                }    
                cont = 1;
                Console.WriteLine("");
                }
                


           }
        }
    }
    public class Group{
        public List<string> Estudiantes {get; set;}
        public List<string> Topics {get; set;}

        public Group(){
            Estudiantes = new List<string>();
            Topics = new List<string>();
        }
    }
   
}
}
