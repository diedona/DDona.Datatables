using DDona.Datatables.Web.Models;
using DDona.Datatables.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDona.Datatables.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDTData(DataTablesViewModel model)
        {
            DataTableReturn dtReturn = new DataTableReturn();
            List<Pessoa> Pessoas = GetAll();
            List<Pessoa> PessoasFiltrado = FiltrarPessoas(Pessoas, model);

            dtReturn.draw = model.draw;
            dtReturn.recordsFiltered = Pessoas.Count;
            dtReturn.recordsTotal = Pessoas.Count;
            dtReturn.data = PessoasFiltrado.ToArray();

            return Json(dtReturn);
        }

        private List<Pessoa> FiltrarPessoas(List<Pessoa> Pessoas, DataTablesViewModel model)
        {
            int QtdPorPagina = model.length;
            int Skip = model.start;

            return Pessoas.OrderBy(x => x.first_name).Skip(Skip).Take(QtdPorPagina).ToList();
        }

        private List<Pessoa> GetAll()
        {
            return new List<Pessoa>()
            {
                new Pessoa(){first_name = "Diego", last_name = "Doná"},
                new Pessoa(){first_name = "Ricardo", last_name = "Oliveira"},
                new Pessoa(){first_name = "Manuel", last_name = "Rodrigues"},
                new Pessoa(){first_name = "Renata", last_name = ""},
                new Pessoa(){first_name = "José", last_name = "C."},
                new Pessoa(){first_name = "Alberto", last_name = "Roberto"},
                new Pessoa(){first_name = "Manuel", last_name = "Oliveira"},
                new Pessoa(){first_name = "Carlos", last_name = "Carlin"},
                new Pessoa(){first_name = "Matildes", last_name = "Magna"},
                new Pessoa(){first_name = "Josefina", last_name = "Josa"},
                new Pessoa(){first_name = "Josefa", last_name = "Rosa"},
                new Pessoa(){first_name = "Aline", last_name = "Santos"},
                new Pessoa(){first_name = "Ricardo", last_name = "Kargha"},
            };
        }
    }
}