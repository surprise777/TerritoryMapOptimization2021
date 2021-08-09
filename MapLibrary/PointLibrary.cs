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
        public double Latitude
        {
            get { return lat; }
            set { lat = value; }
        }
        public double Longitude
        {
            get { return lon; }
            set { lon = value; }
        }

        public GeoPoint()
        {
        }
        public GeoPoint(string pID)
        {
            id = pID;
        }
        /// <summary>
        /// Create a new GeoPoint object
        /// </summary>
        /// <param name="pID">Input point ID</param>
        /// <param name="pLat">Latitude of new point</param>
        /// <param name="pLon">Longitude of new point</param>
        public GeoPoint(string pID, double pLat, double pLon)
        {
            id = pID;
            lat = pLat;
            lon = pLon;
        }
    }




}
