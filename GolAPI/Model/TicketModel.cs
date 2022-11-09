using Google.Cloud.Firestore;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace GolAPI.Model
{
    [FirestoreData]
    public class TicketModel
    {
        [FirestoreProperty]
        public int flightID { get; set; }
        [FirestoreProperty]
        public string passengerID { get; set; } = string.Empty;
    }
}
