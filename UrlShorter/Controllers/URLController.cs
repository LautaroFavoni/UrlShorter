using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UrlShorter.Data;
using UrlShorter.entities;
using UrlShorter.Models;
using UrlShorter.Services;

namespace UrlShorter.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class URLController : ControllerBase
    {
        private readonly URLShortContext _context;
        public URLController(URLShortContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult POSTURL([FromQuery] string URLUser, string? Categoria)
        {
            string larga = string.Empty;
            string corta = string.Empty;
            URLUser = URLUser.ToString();
            URL URLDTO = new URL();

            if (URLUser.Length >6 ) //codigo para ver si es mayor a 6 digitos
            {
                if (_context.URLs.Any(u => u.URLLong == URLUser))    //codigo para ver si esta en la base de datos
                {

                    SumarContador(URLUser);
                    return Ok(URLDTO);
                    //URLDTO = _context.URLs.SingleOrDefault(u => u.URLLong == URLUser);
                    //URLDTO.contador++;
                    //_context.URLs.Update(URLDTO);
                    //_context.SaveChanges();


                }
                else
                {

                    string ShortURL = CrearShortUrl(URLUser);

                    Console.WriteLine(ShortURL);

                    URLDTO = new URL();
                    URLDTO.URLLong = URLUser;
                    URLDTO.URLShort = ShortURL;
                    if (Categoria != null) { URLDTO.Categoria = _context.Categorias.SingleOrDefault(u => u.Name == Categoria); }
                    
                    URLDTO.IdCategoria = URLDTO.Categoria.Id;
                    
                    _context.URLs.Add(URLDTO);
                    _context.SaveChanges();

                    return Ok(URLDTO);
                }

            }
            
            return Ok(URLDTO.ToString());
            
            string CrearShortUrl(string url) 
            {
                // Genera una cadena aleatoria para la URL corta
                StringBuilder shortUrl = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    shortUrl.Append(CharSet[random.Next(CharSet.Length)]);
                }

                return shortUrl.ToString();
            };
            
            void SumarContador(string URLUser ) 
            {
            URLDTO = _context.URLs.SingleOrDefault(u => u.URLLong == URLUser);
                URLDTO.contador++;
            _context.URLs.Update(URLDTO);
            _context.SaveChanges();
            }

        }

        [HttpGet]

        public IActionResult GetURL()
        {
            return Ok(_context.URLs.ToList());
        }

        
    }
}
