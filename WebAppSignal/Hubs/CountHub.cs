﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebAppSignal.Hubs
{
    public class CountHub : Hub
    {
        public const string PathAndFileName = "./Files/Count.txt";
        public async Task GetServerCount()
        {
            int count = await GetCountAsync();
            await Clients.All.SendAsync("GetClientCount", count.ToString());
        }

        public async Task<int> GetCountAsync()
        {
            if (File.Exists("./Files/Count.txt") == false)
            {
                using FileStream fileStream = File.Create(PathAndFileName);
            }
            string countText = "";
            using (StreamReader readTxt = new StreamReader(PathAndFileName))
            {
                countText = await readTxt.ReadLineAsync();
                if (string.IsNullOrEmpty(countText)) countText = "0";
            }
            int count = int.Parse(countText) + 1;
            using (StreamWriter writeTxt = new StreamWriter(PathAndFileName, false))
            {
                await writeTxt.WriteAsync($"{count}");
            }
            return count;
        }
    }
}
