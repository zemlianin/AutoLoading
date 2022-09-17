using APILoad.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILoad.Controllers
{

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public int Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // ������� ��� ������� User
                var comp1 = new Company();

                User user1 = new User() {Company = comp1} ;
                User user2 = new User();

                // ��������� �� � ��
                db.Companies.Add(comp1);
                db.Users.Add(user1);
                
                db.SaveChanges();
              
                // �������� ������� �� �� � ������� �� �������
                var users = db.Users.ToList();

                return users[users.Count-1].Company.Id;
            }
        }
    }
}