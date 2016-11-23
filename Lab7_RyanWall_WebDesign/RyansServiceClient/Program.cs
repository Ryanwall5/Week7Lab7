﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace RyansServiceClient
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var users = await GetUserAsync("user");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2} | {3} | {4}", user.FirstName, user.LastName, user.Email, user.NickName, user.Address, user.FavoriteNBATeam, user.DoYouPlayVG))
            }


            Console.ReadLine();
        }

        static async Task<User> GetUserAsync(string path)
        {
            IEnumerable<User> users = null;
            HttpRequestMessage response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }

        }

        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string NickName { get; set; }
            public string Address { get; set; }
            public string FavoriteNBATeam { get; set; }
            public bool DoYouPlayVG { get; set; }
        }


    }
}
