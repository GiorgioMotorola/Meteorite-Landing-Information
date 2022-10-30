﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kentucky_Semester_One_Final_Project
{
    internal class Start
    {
        public static async Task StartProgram()
        {


            string url = "https://raw.githubusercontent.com/GiorgioMotorola/Rate-Your-Music-Top-500-JSON/main/JSON";

            HttpClient client = new HttpClient();

            try
            {
                var httpResponseMessage = await client.GetAsync(url);
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);
                


                Console.WriteLine("pick");
                var pick = Console.ReadLine();
                Console.Beep(650, 100);


                foreach (var post in myPosts)
                {

                    if (pick == "1")
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{post.position}. {post.artist} - {post.name}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Genre: {post.genres}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"User Rating: {post.rating} || Number of User Ratings: {post.num_ratings} || Number of User Reviews: {post.num_reviews}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Year Released: {post.date}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("____________________________________________________________________________________________________");
                        Console.WriteLine("===================================================================================================|");
                        Console.WriteLine("___________________________________________________________________________________________________|");


                    }
                    else if (pick == "2")
                    {
                        if (post.position <= 10)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"{post.position}. {post.artist} - {post.name}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Genre: {post.genres}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"User Rating: {post.rating} || Number of User Ratings: {post.num_ratings} || Number of User Reviews: {post.num_reviews}");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Year Released: {post.date}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("____________________________________________________________________________________________________");
                            Console.WriteLine("===================================================================================================|");
                            Console.WriteLine("___________________________________________________________________________________________________|");
                        }
                    }
                    else if (pick == "3" )
                    {
                        List<string> artistLists = new List<string>();
                        List<string> genresList = new List<string>();
                        List<string> nameList = new List<string>();

                        foreach (var get in myPosts)
                        {
                            
                            string? artist = get.artist;
                            string? genres = get.genres;
                            string? names = (string?)get.name;
                            string[] strings = genres.Split(",");
                            foreach (string s in strings)
                            {
                                if (!genresList.Contains(s) && !artistLists.Contains(s) && !nameList.Contains(s))
                                {
                                    artistLists.Add(s);
                                    genresList.Add(s);
                                    nameList.Add(s);    

                                    if (s.Contains("Rock"))
                                    {
                                        Console.WriteLine($"Artist: {artist} - {names} || Genre: {s}");
                                        
                                    }
                                }
                                


                            }

                        }

                    } else if (pick == "4")
                    {
                        List<string> artistLists = new List<string>();
                        List<string> genresList = new List<string>();
                        List<string> nameList = new List<string>();

                        foreach (var get in myPosts)
                        {
                            
                            string? artist = get.artist;
                            string? genres = get.genres;
                            string? names = (string?)get.name;
                            string[] strings = genres.Split(",");
                            foreach (string s in strings)
                            {
                                if (!genresList.Contains(s) && !artistLists.Contains(s) && !nameList.Contains(s))
                                {
                                    artistLists.Add(s);
                                    genresList.Add(s);

                                    if (s.Contains("Metal"))
                                    {
                                        Console.WriteLine($"Artist: {artist} - {names} Genre: {s}");

                                    }
                                }



                            }

                        }
                    }


                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                client.Dispose();
            }
        }
    }
}