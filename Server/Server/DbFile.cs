using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTorrent
{
    class DbFile
    {
        public int IdFile { get; set; } 
        public string Filename { get; set; }
        public long Dimension { get; set; }
        public string Username { get; set; }

        public DbFile(int idFile, string filename, long dimension, string username)
        {
            IdFile = idFile;
            Filename = filename;
            Dimension = dimension;
            Username = username;
        }

        public override string ToString()
        {
            return IdFile + "\t " + Username + "\t " + Filename + "\t " + Dimension;
        }
    }
}
