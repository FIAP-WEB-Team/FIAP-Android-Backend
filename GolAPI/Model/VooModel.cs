using Google.Cloud.Firestore;

namespace GolAPI.Model
{
    [FirestoreData]
    public class VooModel
    {
        [FirestoreProperty]
        public int FlightNumber { get; set; }
        [FirestoreProperty]
        public string Departure { get; set; } =string.Empty;
        [FirestoreProperty]
        public string Arrival { get; set; } =string.Empty;
        [FirestoreProperty]
        public DateTime DepartureDate { get; set; } = DateTime.Now;
        [FirestoreProperty]
        public DateTime ArrivalDate { get; set; } = DateTime.Now;
    }
}
