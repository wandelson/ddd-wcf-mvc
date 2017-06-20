using AppService.Interfaces;
using AppService.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    [RoutePrefix("clientes")]
    [Route("{action=listar}")]
    public class ClientesController : Controller
    {
        private readonly IClienteApplication _clienteApplication;

        public ClientesController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_clienteApplication.ObterTodos());
        }

        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApplication.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteTelefoneEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteApplication.Adicionar(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(clienteEnderecoViewModel);
                }

                if (!clienteEnderecoViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = clienteEnderecoViewModel.ValidationResult.Message;
                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApplication.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = id;
            return View(clienteViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApplication.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApplication.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteApplication.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_EnderecosList", _clienteApplication.ObterPorId(id).Enderecos);
        }

        [Route("adicionar-endereco")]
        public ActionResult AdicionarEndereco(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_AdicionarEndereco");
        }

        [Route("adicionar-endereco")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApplication.AdicionarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        [Route("adicionar-endereco/{id:guid}")]
        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _clienteApplication.ObterEnderecoPorId(id));
        }

        [Route("adicionar-endereco/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApplication.AtualizarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", enderecoViewModel);
        }

        [Route("excluir-endereco/{id:guid}")]
        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enderecoViewModel = _clienteApplication.ObterEnderecoPorId(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Clientes/Delete/5

        [Route("excluir-endereco/{id:guid}")]
        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var clienteId = _clienteApplication.ObterEnderecoPorId(id).ClienteId;
            _clienteApplication.RemoverEndereco(id);

            string url = Url.Action("ListarEnderecos", "Clientes", new { id = clienteId });
            return Json(new { success = true, url = url });
        }

        public ActionResult ListarTelefones(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_TelefonesList", _clienteApplication.ObterPorId(id).Telefones);
        }

        [Route("adicionar-telefone")]
        public ActionResult AdicionarTelefone(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_AdicionarTelefone");
        }

        [Route("adicionar-telefone")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApplication.AdicionarTelefone(telefoneViewModel);

                string url = Url.Action("ListarTelefones", "Clientes", new { id = telefoneViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarTelefone", telefoneViewModel);
        }

        [Route("adicionar-telefone/{id:guid}")]
        public ActionResult AtualizarTelefone(Guid id)
        {
            return PartialView("_AtualizarTelefone", _clienteApplication.ObterTelefonePorId(id));
        }

        [Route("adicionar-telefone/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApplication.AtualizarTelefone(telefoneViewModel);

                string url = Url.Action("ListarTelefones", "Clientes", new { id = telefoneViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarTelefone", telefoneViewModel);
        }

        [Route("excluir-telefone/{id:guid}")]
        public ActionResult DeletarTelefone(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var telefoneViewModel = _clienteApplication.ObterTelefonePorId(id.Value);
            if (telefoneViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarTelefone", telefoneViewModel);
        }

        // POST: Clientes/Delete/5

        [Route("excluir-telefone/{id:guid}")]
        [HttpPost, ActionName("DeletarTelefone")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarTelefoneConfirmed(Guid id)
        {
            var clienteId = _clienteApplication.ObterTelefonePorId(id).ClienteId;
            _clienteApplication.RemoverTelefone(id);

            string url = Url.Action("ListarTelefones", "Clientes", new { id = clienteId });
            return Json(new { success = true, url = url });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteApplication.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}