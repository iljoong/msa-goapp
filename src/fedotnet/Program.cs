using System;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fedotnet
{
    class Program
    {
        static Google.GoogleClient webclient, imgclient, vidclient;

        static void Main(string[] args)
        {
            string webbackends = Environment.GetEnvironmentVariable("DN_WEBBACKENDS") ?? "localhost:36061";
            string imgbackends = Environment.GetEnvironmentVariable("DN_IMGBACKENDS") ?? "localhost:36071";
            string vidbackends = Environment.GetEnvironmentVariable("DN_VIDBACKENDS") ?? "localhost:36081";

            Channel webchannel = new Channel(webbackends, ChannelCredentials.Insecure);
            webclient = new Google.GoogleClient(webchannel);

            Channel imgchannel = new Channel(imgbackends, ChannelCredentials.Insecure);
            imgclient = new Google.GoogleClient(webchannel);

            Channel vidchannel = new Channel(vidbackends, ChannelCredentials.Insecure);
            vidclient = new Google.GoogleClient(vidchannel);

            String query = "test";
            if (args.Length > 1)
            {
                query = args[1];
            }

            int start_time = DateTime.Now.Millisecond;
            
            //List<Result> res = searchSearch(query);

            // c#7 does not support `static aync Task Main()`
            //List<Result> res = await searchSearchAsync(query);
            var res = Task.Run(async () => { return await searchSearchAsync(query); }).Result;

            int elapsed_time = DateTime.Now.Millisecond - start_time;

            Console.WriteLine($"Search Result: {elapsed_time} msec\n\t{res[0].Log}, \n\t{res[1].Log}, \n\t{res[2].Log}");
            
            webchannel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Sync call
        static List<Result> searchSearch(string query)
        {
            List<Result> res = new List<Result>();

            res.Add(webclient.Search(new Request { Query = query }));
            res.Add(imgclient.Search(new Request { Query = query }));
            res.Add(vidclient.Search(new Request { Query = query }));

            return res;
        }

        // Parallel call
        static async Task<List<Result>> searchSearchAsync(string query)
        {
            List<Result> res = new List<Result>();

            AsyncUnaryCall<Result> res1 = webclient.SearchAsync(new Request { Query = query });
            AsyncUnaryCall<Result> res2 = imgclient.SearchAsync(new Request { Query = query });
            AsyncUnaryCall<Result> res3 = vidclient.SearchAsync(new Request { Query = query });

            res.Add(await res1);
            res.Add(await res2);
            res.Add(await res3);

            return res;
        }
    }
}
