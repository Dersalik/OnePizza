//By Mahamad Sardar
//Software Engineer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace OnePizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\max\Desktop\e_elaborate.in.txt";
          

            List<Client> clients=new List<Client>();

            List<string> lines=File.ReadAllLines(path).ToList();

            Client.ClientNumber=int.Parse(lines[0]);


            for (int i = 1; i <= Client.ClientNumber * 2; i += 2)
            {
                var line1 = lines[i];
                Client newClient = new Client();
                string[] st1 = line1.Split(' ');

                int counter = 0;
                newClient.LikedIngredientNum = int.Parse(st1[counter]);
                counter++;

                int j = 0;
                List<Ingredient> listLiked = new List<Ingredient>();
                while (j<newClient.LikedIngredientNum)
                {

                    listLiked.Add(new Ingredient(st1[counter]));
                    j++;
                    counter++;
                }

                newClient.LikedIngredients = listLiked;

                
                var line2=lines[i+1];

                string[] st2 = line2.Split(' ');
                counter = 0;

                newClient.DislilkedIngredientNum=int.Parse(st2[counter]);
                counter++;

                j = 0;
                List<Ingredient> listDisliked=  new List<Ingredient>();
                while (j < newClient.DislilkedIngredientNum)
                {
                      listDisliked.Add(new Ingredient(st2[counter]));
                    j++;
                    counter++;


                }

                newClient.DislikedIngredients = listDisliked;


                clients.Add(newClient);
            }

            
            List<Ingredient> listOfAllLikedIngredients=new List<Ingredient>();

            
            for (int i=0; i<Client.ClientNumber; i++)
            {
                int k = 0;
                while (k < clients[i].LikedIngredientNum)
                {
                    listOfAllLikedIngredients.Add(clients[i].LikedIngredients[k]);

                    k++;
                }
            }


            List<Ingredient> listOfAllDilikedIngredients = new List<Ingredient>();


            for (int i = 0; i < Client.ClientNumber; i++)
            {


                if (clients[i].DislilkedIngredientNum > 0)
                {
                    int k = 0;
                    while (k < clients[i].DislilkedIngredientNum)
                    {

                        listOfAllDilikedIngredients.Add(clients[i].DislikedIngredients[k]);

                        k++;
                    }
                }

            }


            //foreach(Ingredient ing in listOfAllDilikedIngredients) //for sake of salik I mean testing 
            //{
            //    Console.WriteLine(ing.ingredientName);
            //}


            

            string[] listarray=new string[listOfAllDilikedIngredients.Count+listOfAllLikedIngredients.Count];//this array contains list of all ingredient with duplicate


            int l;
           for (l = 0;l<listOfAllLikedIngredients.Count;l++)
            {
                listarray[l] = listOfAllLikedIngredients[l].ingredientName;
            }
            

            for (int k = l, s=0; s< listOfAllDilikedIngredients.Count; k++,s++)
            {
                listarray[k] = listOfAllDilikedIngredients[s].ingredientName;
            }


          


            //here Every duplicate element will be removed in order to know name of all the ingredients

            
            var sList = new ArrayList();

            for (int i = 0; i < listarray.Length; i++)
            {
                if (sList.Contains(listarray[i]) == false)
                {
                    sList.Add(listarray[i]);
                }
            }

            var sNew = sList.ToArray();

            ////for (int i = 0; i < sNew.Length; i++) //another test method 
            ////{
            ////    Console.WriteLine(sNew[i]);
            ////}

            string[] resultArrayWithNoDup = Array.ConvertAll(sNew, x => x.ToString());

           //test Console.WriteLine(resultArrayWithNoDup[0]);

            List<Ingredient> ingList=new List<Ingredient>();

            for(int i = 0;i<resultArrayWithNoDup.Length;i++)
            {
                Ingredient ingadder=new Ingredient(resultArrayWithNoDup[i]);
                ingList.Add(ingadder);
            }

            //likes occurences
            for(int i = 0;i<ingList.Count ; i++)
            {
                for(int j = 0;j<listOfAllLikedIngredients.Count;j++)
                {
                    if(ingList[i].ingredientName==listOfAllLikedIngredients[j].ingredientName)
                    {
                        ingList[i].numOfLikesByCustomer++;
                    }
                }
            }

            //Console.WriteLine(ingList[0].numOfLikesByCustomer);
            // Console.WriteLine(ingList[0].ingredientName);

            //dislikes occurences
            for (int i = 0; i < ingList.Count; i++)
            {
                for (int j = 0; j < listOfAllDilikedIngredients.Count; j++)
                {
                    if (ingList[i].ingredientName == listOfAllDilikedIngredients[j].ingredientName)
                    {
                        ingList[i].numOfDislikesbycustomer++;
                    }
                }
            }

           // Console.WriteLine(ingList[0].numOfDislikesbycustomer);
            // Console.WriteLine(ingList[0].ingredientName);


            //foreach(Ingredient i in ingList)
            //{
            //    Console.WriteLine(i.ingredientName);
            //    Console.WriteLine(i.numOfDislikesbycustomer);
            //    Console.WriteLine(i.numOfLikesByCustomer);
            //}
            List<Ingredient> finalList=new List<Ingredient>();
            foreach (Ingredient i in ingList)
            {
                if(i.numOfLikesByCustomer>i.numOfDislikesbycustomer)
                {
                    finalList.Add(i);
                }
            }
            Console.WriteLine(finalList.Count);

            //var top4 = finalList.OrderByDescending(o => o.numOfLikesByCustomer).Take(4);



            //List<Ingredient> topper=top4.ToList();
            ////Console.WriteLine(topper[0].ingredientName);
            ////Console.WriteLine(topper[0].numOfLikesByCustomer);

            ////foreach (Ingredient i in finalList)
            ////{
            ////    Console.WriteLine(i.ingredientName);
            ////}

            string num=finalList.ToString();
             List<string> output = new List<string>();
            output.Insert(0,num);
            string writebackfile = @"C:\Users\max\Desktop\e_elaborate.ou.txt";
            output[0] =finalList.Count.ToString();
            for (int i = 0;i < finalList.Count;i++)
            {
                output[0]=output[0]+" "+finalList[i].ingredientName;
            }

                
            
            

            File.WriteAllLines(writebackfile, output);

            Console.ReadLine();
        }

        

        
    }
}

