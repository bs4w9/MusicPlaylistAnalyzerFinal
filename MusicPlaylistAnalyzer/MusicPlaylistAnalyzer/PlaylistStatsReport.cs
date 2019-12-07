using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer

{
    public static class PlaylistStatsReport
    {
        public static string GenerateText(List<PlaylistStats> playlistStatsList)
        {
            string report = "Playlist Analyzer Report\n\n";

            if (playlistStatsList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            else
            {
                report += "Songs that received 200 or more plays: \n";
                var twohundred = from playlistStats in playlistStatsList where playlistStats.Plays > 200 select playlistStats;
                if (twohundred.Count() > 0)
                {
                    foreach (var twohund in twohundred)
                    {
                        report += "Name: " + twohund.Name + ", Artist: " + twohund.Artist + ", Album: " + twohund.Album + ", Genre: " + twohund.Genre
                            + ", Size: " + twohund.Size + ", Time: " + twohund.Time + ", Year: " + twohund.Year + ", Plays: " + twohund.Plays;
                        report += "\n";


                    }

                }
                else
                {
                    report += "not available\n";
                }

                report += "Number of Alternative songs: ";
                var altsongs = from playlistStats in playlistStatsList where playlistStats.Genre == "Alternative" select playlistStats;
                if (altsongs.Count() > 0)
                {
                    int altcount = 0;
                    foreach (var altsong in altsongs)
                    {
                        altcount += 1;

                    }
                    report += altcount;

                }
                else
                {
                    report += "not available\n";
                }

                report += "Number of Hip-Hop/Rap songs:";
                var rapsongs = from playlistStats in playlistStatsList where playlistStats.Genre == "Hip-Hop/Rap" select playlistStats;
                if (rapsongs.Count() > 0)
                {
                    int rapcount = 0;
                    foreach (var rapsong in rapsongs)
                    {
                        rapcount += 1;

                    }
                    report += rapcount;

                }
                else
                {
                    report += "not available\n";
                }

                report += "Songs from the album Welcome to the Fishbowl: \n";
                var wttfbsongs = from playlistStats in playlistStatsList where playlistStats.Album == "Welcome to the Fishbowl" select playlistStats;
                if (wttfbsongs.Count() > 0)
                {
                    foreach (var wttfbsong in wttfbsongs)
                    {
                        report += "Name: " + wttfbsong.Name + ", Artist: " + wttfbsong.Artist + ", Album: " + wttfbsong.Album + ", Genre: " + wttfbsong.Genre
                            + ", Size: " + wttfbsong.Size + ", Time: " + wttfbsong.Time + ", Year: " + wttfbsong.Year + ", Plays: " + wttfbsong.Plays;
                        report += "\n";


                    }

                }
                else
                {
                    report += "not available\n";
                }

                report += "Songs from before 1970: \n";
                var sevsongs = from playlistStats in playlistStatsList where playlistStats.Year < 1970 select playlistStats;
                if (sevsongs.Count() > 0)
                {
                    foreach (var sevsong in sevsongs)
                    {
                        report += "Name: " + sevsong.Name + ", Artist: " + sevsong.Artist + ", Album: " + sevsong.Album + ", Genre: " + sevsong.Genre
                            + ", Size: " + sevsong.Size + ", Time: " + sevsong.Time + ", Year: " + sevsong.Year + ", Plays: " + sevsong.Plays;
                        report += "\n";


                    }

                }
                else
                {
                    report += "not available\n";
                }

                report += "Song names longer than 85 characters: \n";
                var longsongs = from playlistStats in playlistStatsList where playlistStats.Name.Length > 85 select playlistStats;
                if (longsongs.Count() > 0)
                {
                    foreach (var longsong in longsongs)
                    {
                        report += "Name: " + longsong.Name + ", Artist: " + longsong.Artist + ", Album: " + longsong.Album + ", Genre: " + longsong.Genre
                            + ", Size: " + longsong.Size + ", Time: " + longsong.Time + ", Year: " + longsong.Year + ", Plays: " + longsong.Plays;
                        report += "\n";


                    }

                }
                else
                {
                    report += "not available\n";
                }

                report += "Longest song: \n";
                var songlength = (from playlistStats in playlistStatsList select playlistStats.Time).Max();
                var longestsongs = from playlistStats in playlistStatsList where playlistStats.Time == songlength select playlistStats;
                foreach (var i in longestsongs)
                {
                    report += "Name: " + i.Name + ", Artist: " + i.Artist + ", Album: " + i.Album + ", Genre: " + i.Genre
                        + ", Size: " + i.Size + ", Time: " + i.Time + ", Year: " + i.Year + ", Plays: " + i.Plays;
                    report += "\n";
                }

            }

            return report;
        }
    }
}
