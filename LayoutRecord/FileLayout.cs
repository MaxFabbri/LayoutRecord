using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutRecord
{
    public class FileLayout
    {

        string fileName;
        readonly List<Layout> layoutRecord = new List<Layout>();

        public FileLayout(string fileName, string trackDescription, Layout layoutRecord)
        {
            this.fileName = fileName;
            layoutRecord.trackDescription= trackDescription;
            this.layoutRecord.Add(layoutRecord);

            if (File.Exists(fileName))
                File.Delete(fileName);

        }

        public bool WriteLine(string trackDescription="")
        {
            bool error=false; 
            if (layoutRecord.Count > 0)
            {
                string layout;
                if (trackDescription == "")
                    layout = layoutRecord[0].ToString();
                else
                    layout = layoutRecord.FirstOrDefault(x => x.trackDescription == trackDescription).ToString();

                if (layout != "")
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(fileName,true))
                        {
                            // scrive sul file fileName in base al nome della traccia TrackName
                            writer.Write(layout);
                        }
                    }
                    catch
                    {
                        error = true;
                    }
                }
                else {
                    error = true;
                }
            }
            return error;
        }

        public void AddLayout(string trackDescription, Layout layoutRecord)
        {
            layoutRecord.trackDescription = trackDescription;
            this.layoutRecord.Add(layoutRecord);
        }
    }

}
