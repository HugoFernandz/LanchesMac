﻿using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
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
        public IActionResult List(string categoria)
        {
            #region ViewDataExemplo
            //// tipo uma seção, o mais rapido.
            //ViewData["Titulo"] = "Todos os lanches";
            //ViewData["Data"] = DateTime.Now;
            #endregion

            //var lanches = _lancheRepository.Lanches;

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

            //return View(lanches);

            //var lanchesListViewModel = new LancheListViewModel();
            //lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            //lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).OrderBy(c => c.Nome);
                
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                //}

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
    }
}
