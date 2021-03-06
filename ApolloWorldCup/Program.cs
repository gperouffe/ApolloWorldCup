﻿using Slack.Webhooks;
using System;
using System.Linq;

namespace ApolloWorldCup
{
    class Program
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static SlackApi _slackApi;
        public static SlackBot _slackBot;
        public static WorldCupApi _wcApi;
        public static bool _enableSlackApi = false;

        public static string _channelId = "CAZAYAE1G";

        static void Main(string[] args)
        {
            try
            {
                string webhook = null;
                string token = null;
                string channelId = _channelId;
                if (args != null)
                {
                    if (args.Length > 0)
                    {
                        webhook = args[0];
                        _enableSlackApi = true;
                    }
                    if (args.Length > 1)
                    {
                        token = args[1];
                    }
                    if (args.Length > 2)
                    {
                        channelId = args[2];
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Start");
                Console.ForegroundColor = ConsoleColor.White;

                _wcApi = new WorldCupApi();
                _slackApi = new SlackApi(webhook);

                _slackBot = new SlackBot(_slackApi, _wcApi, channelId, token);
                _slackBot.Start();

                Console.ReadKey();

                _slackBot.Stop();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("End");

            }
            catch (Exception e) {
                log.Error(e);
            }
        }

    }
}
