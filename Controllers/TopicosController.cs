using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entities.Controllers
{
    public class TopicosController : Controller
    {
        private readonly Contexto _contexto;

        public TopicosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch
            {

                // Redirecione ou retorne uma resposta de erro
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<JsonResult> PegarTodos()
        {
            return Json(await _contexto.Topicos.ToListAsync());

        }

        [HttpPost]
        public async Task<JsonResult> NovoTopico(Topico topico)
        {
            if (ModelState.IsValid)
            {
                await _contexto.Topicos.AddAsync(topico);
                await _contexto.SaveChangesAsync();
                return Json(topico);
            }

            return Json(ModelState);

        }

        [HttpGet]
        public async Task<JsonResult> PegarTopicoPeloId(int topicoId)
        {
            Topico topico = await _contexto.Topicos.FindAsync(topicoId);
            return Json(topico);
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarTopico(Topico topico)
        {
            if (ModelState.IsValid)
            {
                _contexto.Topicos.Update(topico);
                await _contexto.SaveChangesAsync();
                return Json(topico);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirTopico(int Id)
        {
            Topico topico = await _contexto.Topicos.FindAsync(Id);

            if (topico != null)
            {
                _contexto.Topicos.Remove(topico);
                await _contexto.SaveChangesAsync();
                return Json(true);
            }

            return Json(new
            {
                mensagem = "Topico não encontrado"
            });
        }
    }
}