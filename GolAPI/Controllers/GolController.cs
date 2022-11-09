using GolAPI.DbContext;
using GolAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GolAPI.Controllers
{
    [ApiController]
    [Route("GolAPI")]
    public class GolController : ControllerBase
    {
        

        private readonly DataContexto DbContext;

        public GolController(DataContexto db)
        {
            this.DbContext = db;
        }
        [HttpPost]
        [Route("/login")]
        public  string GetToken([FromBody] UserModel user) 
        {
            if (user.User == "FiapTrabalho" & user.Password == "153020@10gH")
            {
                return Token.TokenService.GenerateToken();
            }
            else 
            {
                return "senha incorreta";
            }

        }

        [HttpPost]
        [Route("/setpassengers")]
        [Authorize (Roles = "manager")]
        public async Task<string> SetPassengersAsync([FromBody] DTOPassageiroModel passenger)
        {
            return await DbContext.SetPassengersAsync(passenger);
        }
        [HttpGet]
        [Route("/getpassengers")]
        [Authorize(Roles = "manager")]
        public async Task<List<PassageiroModel>> GetPassengersAsync()
        {

            List<PassageiroModel> listaPassageiros = await DbContext.GetPassengersAsync();
            return listaPassageiros;
        }
        [HttpPost]
        [Route("/setflights")]
        [Authorize(Roles = "manager")]
        public async void SetFlights([FromBody] VooModel flights)
        {
            await DbContext.SetFlightAsync(flights);
        }
        [HttpGet]
        [Route("/getflights")]
        [Authorize(Roles = "manager")]
       
        public async Task<List<VooModel>> GetFlights()
        {
            List<VooModel> listaVoos = await DbContext.GetFlightsAsync();
            return listaVoos;
        }
        [HttpPost]
        [Route("/buyTicket")]
        [Authorize(Roles = "manager")]
        public async Task<string> BuyTicket([FromBody] TicketModel TM)
        {
            try
            {

                await DbContext.SetBuyTicketAsync(TM);
                return "successful purchase!";
            }
            catch (Exception e)
            {
                return "error on purchase!" + e.ToString();
            }
        }
        [HttpGet]
        [Route("/getTicket")]
        [Authorize(Roles = "manager")]
        public async Task<List<TicketModel>> GetTicket()
        {

            return await DbContext.GetBuyTicketAsync();
        }



    }
}
