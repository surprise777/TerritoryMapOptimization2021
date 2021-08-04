namespace MapLibrary
{
    public class GeoPoint
    {
        private string id;
        private double lat;
        private double lon;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }
        public double Lon
        {
            get { return lon; }
            set { lon = value; }
        }

        public GeoPoint()
        {
            ;
        }
        public GeoPoint(string pID)
        {
            id = pID;
        }
        public GeoPoint(string pID, double pLat, double pLon)
        {
            id = pID;
            lat = pLat;
            lon = pLon;
        }
    }




}
