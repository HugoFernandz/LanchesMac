using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
                _lancheRepository = lancheRepository;
        }
        public IActionResult List()
        {
            #region ViewDataExemplo
            //// tipo uma seção, o mais rapido.
            //ViewData["Titulo"] = "Todos os lanches";
            //ViewData["Data"] = DateTime.Now;
            #endregion

            var lanches = _lancheRepository.Lanches;

            #region ViewBagExemplo
            //var totalLanches = lanches.Count();

            //// pode ser nomeado como preferir e inserir algum valor. o mais usado
            //ViewBag.Total = "Total de lanches : ";
            //ViewBag.TotalLanches = totalLanches;
            #endregion

            #region TempDataExemplo
            // tipo uma seção, mas só pode recuperar o valor 1 vez. ex: declara na home e recupera na pagina de lanches
            //TempData["Nome"] = "Victor";
            #endregion

            return View(lanches);
        }
    }
}
