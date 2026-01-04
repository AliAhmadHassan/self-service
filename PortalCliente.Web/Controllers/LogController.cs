using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index(int? id)
        {
            List<Models.Log> logModels = new List<Models.Log>();
            int LinePages = 0;
            int i = 0;

            if (id == 0 || id == null)
            {
                #region First
                foreach (var item in new BLL.Log().Select())
                {
                    Models.Log log = item.GetModels<Models.Log>();
                    log.LogStatus = new BLL.LogStatus().SelectById(log.LogStatusId).Descricao;
                    DTO.Cliente cliente = new BLL.Cliente().SelectById(log.ClienteId);
                    log.Nome = cliente.Nome;
                    log.CPF_CNPJ = cliente.CpfCnpj;
                    log.id = 0;
                    logModels.Add(log);

                    i++;

                    if (i > 10)
                    {
                        ViewBag.Id = log.id;
                        return View(logModels);
                    }
                }
                #endregion
            }
            else
            {
                #region Paginar
                foreach (var item in new BLL.Log().Select())
                {
                    Models.Log log = item.GetModels<Models.Log>();
                    log.LogStatus = new BLL.LogStatus().SelectById(log.LogStatusId).Descricao;
                    DTO.Cliente cliente = new BLL.Cliente().SelectById(log.ClienteId);
                    log.Nome = cliente.Nome;
                    log.CPF_CNPJ = cliente.CpfCnpj;
                    log.id = int.Parse(id.ToString());

                    if (i > 10 * id)
                    {
                        logModels.Add(log);
                        LinePages++;
                    }

                    if (i > 10 * (id+1))
                    {
                        ViewBag.Id = log.id;
                        return View(logModels);
                    }

                    i++;
                }
                #endregion
            }

            return View(logModels);
        }
    }
}