/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 
using System;
using System.IO;

namespace PleaseBLL
{
    public class Logger
    {

        public bool fileLocked = false;
        public string Path;

        public Logger(string path)
        {
            Path = path;
        }

        public void Log(string log)
        {
            while(fileLocked) { System.Threading.Thread.Sleep(50); }
            fileLocked = true;
            using (StreamWriter w = new StreamWriter(Path, true))
            {
                w.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString(), log));
                w.Close();
            }
            fileLocked = false;
        }

    }
}

