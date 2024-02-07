using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Discord;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Specialized;
class Program
{


    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string discriminator { get; set; }
        public int public_flags { get; set; }
    }
    public static void GetInfo()
    {
        try
        {

            char[] delimiterchar = { '{', '}', ',' };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter token: ");
            string token = Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://canary.discord.com/api/v9/users/@me");
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("authorization", token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string info = readStream.ReadToEnd();
            string[] sortedinfo = info.Split(delimiterchar);
            DiscordClient client = new DiscordClient(token, null);
            foreach (var word in sortedinfo)
            {
                Console.WriteLine(word);
            }
            response.Close();
            readStream.Close();
            Console.WriteLine("Nitro Status: " + client.User.Nitro);

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("exception caught. \n" + e);
        }
    }
    public static void GetFriends()
    {
        try
        {
            char[] delimiterchar = { '{', '}', ',', ']', '[' };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter your token: ");
            string token = Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://canary.discord.com/api/v8/users/@me/relationships");
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("authorization", token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string info = readStream.ReadToEnd();
            string[] sortedinfo = info.Split(delimiterchar);
            foreach (var word in sortedinfo)
            {
                Console.WriteLine(word);
            }
            response.Close();
            readStream.Close();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("exception caught. \n" + e);
        }

    }
    public static void SpamGuilds()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token, null);
        for (int i = 0; i < 20; i++)
        {
            client.CreateGuild("vinnie runs", null, null);
            Thread.Sleep(100);
        }

    }
    public static void GetOwnedGuilds()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token, null);
        foreach (var guild in client.GetGuilds())
        {
            if (guild.Owner == true)
            {
                Console.WriteLine(guild.Name);
            }
        }
    }
    public static void GetAdminGuilds()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token, null);
        foreach (var guild in client.GetGuilds())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("if 2199023255551 means that they have admin perms");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(guild.Permissions + " " + guild.Name);
            Thread.Sleep(1000);
        }
    }
    public static void SpamUserSettings()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token, null);
        for (int i = 0; i < 35; i++)
        {
            client.User.ChangeSettings(new UserSettingsProperties()
            {
                Theme = DiscordTheme.Light,
                DeveloperMode = true,
                Language = DiscordLanguage.Korean,
                CustomStatus = new CustomStatus()
                {
                    Text = "killing jews",
                    EmojiName = "🔥" // remember to pass EmojiId if it's a custom emoji
                }
            });
            client.User.ChangeSettings(new UserSettingsProperties()
            {
                Theme = DiscordTheme.Dark,
                DeveloperMode = true,
                Language = DiscordLanguage.Chinese,
                CustomStatus = new CustomStatus()
                {
                    Text = "cat mafia runs",
                    EmojiName = "🔥" // remember to pass EmojiId if it's a custom emoji
                }
            });
        }

    }
    public static void MassDM()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token);
        foreach (var channel in client.GetPrivateChannels())
        {
            channel.SendMessage("I like cat mafia");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Message sent");
        }
    }
    public static void DeleteAccount()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your token: ");
        string token = Console.ReadLine();
        Console.Write("Enter password:");
        string password = Console.ReadLine();
        DiscordClient client = new DiscordClient(token);
        client.User.Delete(password);

    }
    public static void Menu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("[1] Get info [2] Get Friends [3] Spam Guilds [4] Remove Friends [5] Webhook Spammer [6] Spam User Settings [7] Get Owned Guilds [8] Get Admin Guilds [9] Mass DM [10] Delete Account");
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("Enter option: ");
        string option = Console.ReadLine();
        if (option == "1")
        {
            try
            {
            GetInfo();
            Thread.Sleep(10000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "2")
        {
            try
            {
            GetFriends();
            Thread.Sleep(10000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "3")
        {
            try
            {
            SpamGuilds();
            Thread.Sleep(10000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "4")
        {
            try
            {
            RemoveFriends();
            Thread.Sleep(10000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "5")
        {
            try
            {            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please Input the Message: ");
            string message = Console.ReadLine();
            Console.Write("Please input name of webhook: ");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please input webhook URL: ");
            string webhook = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                WebhookSpam(webhook, message, name);
                Thread.Sleep(69);
            }
            Thread.Sleep(100000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "6")
        {
            try{
            SpamUserSettings();
            Thread.Sleep(100000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "7")
        {
            try
            {
            GetOwnedGuilds();
            Thread.Sleep(15000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }

        }
        else if (option == "8")
        {
            try
            {
            GetAdminGuilds();
            Thread.Sleep(100000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "9")
        {
            try
            {
            MassDM();
            Thread.Sleep(100000);
            Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "10")
        {
            try
            {
                DeleteAccount();
                Thread.Sleep(100000);
                Menu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Menu();
            }
        }
        else if (option == "c")
        {
            Console.Clear();
            Menu();
        }

    }
    public static void RemoveFriends()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter token: ");
        string token = Console.ReadLine();
        DiscordClient client = new DiscordClient(token, null);
        foreach (var relationship in client.GetRelationships())
        {
            relationship.Remove();
        }
    }

    public static void WebhookSpam(string webhook, string message, string name)
    {
        {
            try
            {
                _ = Http.Post(webhook, new NameValueCollection()
                {
                {
                    "username",
                    name

                },
                {
                    "content",
                    message
                },


            });
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(System.DateTime.Now.ToString("[hh:mm:ss]") + "> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[+] Successfully sended Webhook!");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(System.DateTime.Now.ToString("[hh:mm:ss]") + "> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[-] Couldn't send Webhook!");
            }
        }


    }
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Made by vinnie43934 :> | https://github.com/vinniedaboi");
            Menu();
        }
    }

// test token: "OTM1NDEwNzIwMTY0Njc1NzI0.YfnVsA.Go6yfzuSg4IGWrqVGSgIcwgh_ks"
// https://discord.com/api/webhooks/944483460460974110/BskR7usgp3J0Be5OWdNxWNaZ32_Xx5QOjkW7tsLF5tAouYDYZRGGzj21AlXMLwhV8Ybv



//dotnet publish --output "C:\Users\vincentngsoonzheng" --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true