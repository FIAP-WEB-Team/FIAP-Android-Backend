using GolAPI.Model;
using Google.Cloud.Firestore;
using System.Diagnostics.CodeAnalysis;

namespace GolAPI.DbContext
{
    public class DataContexto
    {
        FirestoreDb database;

        public DataContexto()
        {
            OpenFirebaseConnection();
        }

        public void OpenFirebaseConnection() 
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "golapi-5c457-firebase-adminsdk-bxmj0-85a6c35b95.Json");
             string projectID = "golapi-5c457";
            database = FirestoreDb.Create(projectID);
        }
        public async Task<string> SetPassengersAsync(DTOPassageiroModel DTOModel) 
        {
            try
            {
                DocumentReference passageiroDocument = database.Collection("GolData").Document("Data").Collection("Passengers").Document();
               DocumentSnapshot snapshot = await passageiroDocument.GetSnapshotAsync();
               string id = snapshot.Id;

                PassageiroModel passageiroModel = new PassageiroModel();
                passageiroModel.FirstName = DTOModel.FirstName;
                passageiroModel.LastName = DTOModel.LastName;
                passageiroModel.Nationality = DTOModel.Nationality;
                passageiroModel.BirthDate = DTOModel.BirthDate;
                passageiroModel.Gender = DTOModel.Gender;
                passageiroModel.PassengerID = id;
                await passageiroDocument.SetAsync(passageiroModel);

                return id;
            }
            catch(Exception e)
            {
                return "Houve algum erro na hora de cadastrar o passageiro \n" +e.ToString() +"\n"+e.StackTrace;
            }
           
        }
        public async Task<string> SetFlightAsync(VooModel vooModel)
        {
            
                DocumentReference vooDocument = database.Collection("GolData").Document("Data").Collection("Flights").Document(vooModel.FlightNumber.ToString());
                await vooDocument.SetAsync(vooModel);
                return "voo Cadastrado com sucesso";
            
          

        }



        public async Task<TicketModel> SetBuyTicketAsync(TicketModel TM) 
        {
            try
            {
                DocumentReference doc1 = database.Collection("GolData").Document("Data").Collection("BuyTickets").Document();
                await doc1.SetAsync(TM);
                return TM;
            }
            catch (Exception e)
            {
                return TM ;
            }
        }

        public async Task<List<TicketModel>> GetBuyTicketAsync()
        {
            List<TicketModel> ticketModels = new List<TicketModel>();   
            try
            {
                CollectionReference ticketCollection = database.Collection("GolData").Document("Data").Collection("BuyTickets");
                QuerySnapshot ticketCollectionSnapshot = await ticketCollection.GetSnapshotAsync();

                foreach (DocumentSnapshot docSnap in ticketCollectionSnapshot) 
                {
                    ticketModels.Add(docSnap.ConvertTo<TicketModel>());
                }
                return ticketModels;
            }
            catch 
            {
                return ticketModels;
            }
        }



        public async Task<List<VooModel>> GetFlightsAsync()
        {
            List<VooModel> voos = new List<VooModel>(); 
           
               CollectionReference VoosCollection = database.Collection("GolData").Document("Data").Collection("Flights");
                QuerySnapshot VoosQuery = await VoosCollection.GetSnapshotAsync();
                foreach (DocumentSnapshot VooDoc in VoosQuery) 
                {
                    voos.Add(VooDoc.ConvertTo<VooModel>());
                }

                return voos;
            


        }
        public async Task<List<PassageiroModel>> GetPassengersAsync()
        {
            List<PassageiroModel> passageiros = new List<PassageiroModel>();
           
                CollectionReference passageirosCollection = database.Collection("GolData").Document("Data").Collection("Passengers");
                QuerySnapshot passageirosQuery = await passageirosCollection.GetSnapshotAsync();
                foreach (DocumentSnapshot passageiroDoc in passageirosQuery)
                {
                    passageiros.Add(passageiroDoc.ConvertTo<PassageiroModel>());
                }

                return passageiros;
            


        }
    }
}
