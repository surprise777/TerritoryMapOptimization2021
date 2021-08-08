using System.IO;

namespace MapLibrary
{
    public static class InputFile
    {
        private static string fileName;
        private static FileStream fileIO;
        private static int offSet;
        public static string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public static FileStream FileIO
        {
            get { return fileIO; }
            set { fileIO = value; }
        }
        public static int OffSet
        {
            get { return offSet; }
            set { offSet = value; }
        }
        public static void ReadGeoLines_CSVFile(string csvFile)
        {
            FileName = csvFile;
            FileIO = File.OpenRead(FileName);
            //TODO
        }
        public static void ReadGeoPolygons_CSVFile(string csvFile)
        {
            FileName = csvFile;
            FileIO = File.OpenRead(FileName);
            //TODO

        }


    }
}