using ASPTDD.Models;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ASPTDD.Controllers
{
    public class HomeController : Controller
    {
        private IContatoService _contatoService;
        public HomeController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public ActionResult Index()
        {
            var contatos = _contatoService.ObterTodosContatos();
            var viewModel = new List<ContatoViewModel>(from contato in contatos
                                                       select new ContatoViewModel()
                                                       {
                                                           Id = contato.Id,
                                                           Nome = contato.Nome,
                                                           Sobrenome = contato.Sobrenome,
                                                           Email = contato.Email
                                                       });
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}