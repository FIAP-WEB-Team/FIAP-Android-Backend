using Google.Cloud.Firestore;

namespace GolAPI.Model
{
    [FirestoreData]
    public class PassageiroModel
    {
        [FirestoreProperty]
        public string FirstName { get; set; } = string.Empty;
        [FirestoreProperty]
        public string LastName { get; set; } = string.Empty;
        [FirestoreProperty]
        public string BirthDate { get; set; } = string.Empty;
        [FirestoreProperty]
        public string Nationality { get; set; } = string.Empty;
        [FirestoreProperty]
        public string PassengerID { get; set; } = string.Empty;
        [FirestoreProperty]
        public string Gender { get; set; } = string.Empty;

    }
}
