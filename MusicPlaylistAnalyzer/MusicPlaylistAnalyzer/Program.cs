using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <playlist_txt_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string txtDataFilePath = args[0];
            string reportFilePath = args[1];

            List<PlaylistStats> playlistStatsList = null;
            try
            {
                playlistStatsList = PlaylistStatsLoader.Load(txtDataFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = PlaylistStatsReport.GenerateText(playlistStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}
